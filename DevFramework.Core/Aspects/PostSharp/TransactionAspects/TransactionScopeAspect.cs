using System;
using System.Transactions;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.PostSharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect: OnMethodBoundaryAspect
    {
        private TransactionScopeOption _options;

        public TransactionScopeAspect()
        {
            
        }

        public TransactionScopeAspect(TransactionScopeOption options)
        {
            _options = options;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_options);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}