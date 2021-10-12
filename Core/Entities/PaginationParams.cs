namespace Core.Specifications
{
    public class PaginationParams
    {
        public const int MAXPAGE = 50;
        public int PageIndex { get; set; } = 1; //By default always first page        
        private int _PageSize = 5;

        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = (value > MAXPAGE) ? MAXPAGE : value;
        }
    }
}