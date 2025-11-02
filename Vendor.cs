
namespace CA_Shop
{
    public class Vendor : User
    {
        public List<Category> Categories { get; private set; }

        public Vendor(string name) : base(name, "Vendor") 
        {
            this.Categories = new ();
        }

        public void AddCategory(Category category)
        {
            if (ExistsCategory(category))
            {
                Console.WriteLine("The category already exists");
                return;
            }

            Categories.Add(category);
        }

        public void DeleteCategory(string categoryName)
        {
            var category = FindCategory(categoryName);

            if (!ValidCategory(category)) return;

            Categories.Remove(FindCategory(categoryName));
        }

        public void UpdateCategory(string categoryName, Category updatedCategory)
        {
            var category = FindCategory(categoryName);

            if (!ValidCategory(category)) return;

            int index = Categories.IndexOf(category);
            Categories[index] = updatedCategory;
        }

        public Category ViewCategory(string categoryName)
        {
            var category = FindCategory(categoryName);

            if (!ValidCategory(category)) 
                return null;

            return FindCategory(categoryName);
        }

        public List<Category> ViewAllCategories()
        {
            return Categories;
        }

        private Category FindCategory(string categoryName) => Categories.Find((Category c) => c.CategoryName == categoryName);

        private bool ValidCategory(Category category)
        {
            if(category == null)
            {
                Console.WriteLine("The Category doesn't exists");
                return false;
            }
            return true;
        }

        private bool ExistsCategory(Category category)
        {
            foreach (var c in Categories)
            {
                if ( c.CategoryName == category.CategoryName) return true;
            }
            return false;
        }

    }

}
