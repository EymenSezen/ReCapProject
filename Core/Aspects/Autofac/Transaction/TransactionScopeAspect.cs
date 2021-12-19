using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {

        //transaction yönetimini de bir şablonla yapıyoruz.
        public override void Intercept(IInvocation invocation) //metodumu aldım
        {
            using (TransactionScope transactionScope = new TransactionScope())//işlem kapsamına al
            {
                try
                {
                    invocation.Proceed();   //metodumu çalıştır 
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();   //sonlandır işlem başarısız
                    throw;
                }
            }
        }
    }
}
