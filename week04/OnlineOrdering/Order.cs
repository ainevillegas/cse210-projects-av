using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double productTotal = 0;

        foreach (Product product in _products)
        {
            productTotal += product.CalculateTotalCost();
        }

        double shippingCost;

        if (_customer.LivesInUSA())
        {
            shippingCost = 5;
        }
        else
        {
            shippingCost = 35;
        }

        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();

        foreach (Product product in _products)
        {
            packingLabel.AppendLine(
                $"{product.GetName()} - {product.GetProductId()}");
        }

        return packingLabel.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingInformation();
    }
}