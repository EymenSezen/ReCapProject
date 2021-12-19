using Castle.DynamicProxy;
using Core.CrossCuttingConcerns;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Caching;

namespace Core.Aspects.Autofac.Caching
{       
    //cache aspecti
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;
        
        public CacheAspect(int duration = 60)
        {
            _duration = duration;     //eğer süre atanmamışsa default 60 sn
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); //cache çalışsın
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//ReCap.Business.IProductService.GetAll
            var arguments = invocation.Arguments.ToList();///oradaki argumanları listeye al
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";  //key oluştur parametlerin arasına virgül koy
            if (_cacheManager.IsAdd(key))   //tekrar için breakpoint koy  iki defa send yap
            {
                //cacheda varsa metod dönecek
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();//cachede yoksa çalıştır
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//ve cache ekle
        }
    }
}
