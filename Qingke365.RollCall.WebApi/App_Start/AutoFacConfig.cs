using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Qingke365.RollCall.WebApi.App_Start
{
    public class AutoFacConfig
    {
        public static void Register()
        {
            //初始化AutoFac的相关功能  
            /* 
             1.0 告诉AutoFac初始化数据仓储层FB.CMS.Repository.dll中所有类的对象实例。这些对象实例以其接口的形式保存在AutoFac容器中 
             2.0 告诉AutoFac初始化业务逻辑层FB.CMS.Services.dll中所有类的对象实例。这些对象实例以其接口的形式保存在AutoFac容器中 
             3.0 将MVC默认的控制器工厂替换成AutoFac的工厂 
             */

            //第一步： 构造一个AutoFac的builder容器  
            ContainerBuilder builder = new Autofac.ContainerBuilder();

            //第二步：告诉AutoFac控制器工厂，控制器类的创建去哪些程序集中查找（默认控制器工厂是去扫描bin目录下的所有程序集）  
            //2.1 从当前运行的bin目录下加载FB.CMS.MvcSite.dll程序集  
            Assembly controllerAss = Assembly.Load("Qingke365.RollCall.WebApi");

            //2.2 告诉AutoFac控制器工厂，控制器的创建从controllerAss中查找（注意：RegisterControllers()方法是一个可变参数，如果你的控制器类的创建需要去多个程序集中查找的话，那么我们就再用Assembly controllerBss=Assembly.Load("需要的程序集名")加载需要的程序集，然后与controllerAss组成数组，然后将这个数组传递到RegisterControllers()方法中）  
            builder.RegisterControllers(controllerAss);
            builder.RegisterApiControllers(controllerAss);



            //第三步：告诉AutoFac容器，创建项目中的指定类的对象实例，以接口的形式存储（其实就是创建数据仓储层与业务逻辑层这两个程序集中所有类的对象实例，然后以其接口的形式保存到AutoFac容器内存中，当然如果有需要也可以创建其他程序集的所有类的对象实例，这个只需要我们指定就可以了）  

            //3.1 加载数据仓储层FB.CMS.Repository这个程序集。  
            Assembly repositoryAss = Assembly.Load("Qingke365.RollCall.Dal");
            //3.2 反射扫描这个FB.CMS.Repository.dll程序集中所有的类，得到这个程序集中所有类的集合。  
            Type[] rtypes = repositoryAss.GetTypes();
            //3.3 告诉AutoFac容器，创建rtypes这个集合中所有类的对象实例  
            builder.RegisterTypes(rtypes)
                .AsImplementedInterfaces(); //指明创建的rtypes这个集合中所有类的对象实例，以其接口的形式保存  

            //3.4 加载业务逻辑层FB.CMS.Services这个程序集。  
            Assembly servicesAss = Assembly.Load("Qingke365.RollCall.Bll");
            //3.5 反射扫描这个FB.CMS.Services.dll程序集中所有的类，得到这个程序集中所有类的集合。  
            Type[] stypes = servicesAss.GetTypes();
            //3.6 告诉AutoFac容器，创建stypes这个集合中所有类的对象实例  
            builder.RegisterTypes(stypes)
                .AsImplementedInterfaces(); //指明创建的stypes这个集合中所有类的对象实例，以其接口的形式保存  


            //第四步：创建一个真正的AutoFac的工作容器  
            var container = builder.Build();


            //我们已经创建了指定程序集的所有类的对象实例，并以其接口的形式保存在AutoFac容器内存中了。那么我们怎么去拿它呢？  
            //从AutoFac容器内部根据指定的接口获取其实现类的对象实例  
            //假设我要拿到IsysFunctionServices这个接口的实现类的对象实例，怎么拿呢？  
            //var obj = container.Resolve<IsysFunctionServices>(); //只有有特殊需求的时候可以通过这样的形式来拿。一般情况下没有必要这样来拿，因为AutoFac会自动工作（即：会自动去类的带参数的构造函数中找与容器中key一致的参数类型，并将对象注入到类中，其实就是将对象赋值给构造函数的参数）  


            //第五步：将当前容器中的控制器工厂替换掉MVC默认的控制器工厂。（即：不要MVC默认的控制器工厂了，用AutoFac容器中的控制器工厂替代）此处使用的是将AutoFac工作容器交给MVC底层 (需要using System.Web.Mvc;)  
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}