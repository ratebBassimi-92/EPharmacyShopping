namespace BookShoppingCartMvcUI
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Product>> GetProducts(string sTerm = "", int genreId = 0);
        Task<IEnumerable<Category>> GetCategoris();
    }
}