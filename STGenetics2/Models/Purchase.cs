public class Purchase
{
    public decimal TotalAmount { get; }
    public decimal Discount { get; }
    public decimal ShippingCost { get; }
    public decimal TotalCost { get; }

    public Purchase(decimal totalAmount, decimal discount, decimal shippingCost)
    {
        TotalAmount = totalAmount;
        Discount = discount;
        ShippingCost = shippingCost;
        TotalCost = CalculateTotalCost();
    }

    private decimal CalculateTotalCost()
    {
        decimal discountedAmount = TotalAmount - (TotalAmount * Discount / 100);

        // Aplicar descuento adicional por cantidad de animales
        if (TotalAmount > 10)
            discountedAmount -= (TotalAmount * 3) / 100;

        // Si la cantidad de animales es mayor a 20, el envío es gratis
        if (TotalAmount > 20)
            discountedAmount -= ShippingCost;

        return discountedAmount + ShippingCost;
    }
}
