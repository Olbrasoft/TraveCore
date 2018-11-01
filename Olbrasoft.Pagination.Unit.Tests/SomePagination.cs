namespace Olbrasoft.Pagination.Unit.Tests
{
    internal class SomePagination : BasePagination
    {
        public SomePagination(IPageInfo pageInfo) : base(pageInfo)
        {
        }

        public override int CountWithOutPaging()
        {
            throw new System.NotImplementedException();
        }
    }

    
}