namespace Web_BanDienThoai.Models.Cart
{
    public class IndexCartViewModel
    {
        public IndexCartViewModel()
        {
            CartProductViewModels = new List<CartProductViewModel>();
        }
       public List<CartProductViewModel> CartProductViewModels { get; set; }
    }
}
