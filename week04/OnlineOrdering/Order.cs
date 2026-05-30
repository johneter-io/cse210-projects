class Order
{
    private Customer _customer;
    private List<Product> _products;

    // constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // getter
    public Customer GetCustomer() { return _customer; }

    // setter
    public void SetCustomer(Customer customer) { _customer = customer; }

    // add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // sum of all products + shipping cost
    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.LivesInUSA())
        {
            total += 5;     // USA shipping
        }
        else
        {
            total += 35;    // international shipping
        }

        return total;
    }

    // list the name and id of each product
    public string GetPackingLabel()
    {
        string label = "---- PACKING LABEL ----\n";

        foreach (Product product in _products)
        {
            label += $"  Name: {product.GetName()}\n";
            label += $"  ID: {product.GetProductId()}\n\n";
        }

        return label;
    }

    // return the name and address of the customer
    public string GetShippingLabel()
    {
        string label = "---- SHIPPING LABEL ----\n";
        label += _customer.GetDisplayText();
        return label;
    }
}