namespace MenuExplorer.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public enum MenuCategory
        {
            Appetizer,
            MainCourse,
            Dessert,
            Beverage
        }

        public MenuCategory Category { get; set; }

        public bool IsVegetarian { get; set; }

        public int Rating { get; set; }

    }
}
