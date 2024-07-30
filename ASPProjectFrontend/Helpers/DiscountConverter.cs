namespace ASPProjectFrontend.Helpers;
public static class DiscountConverter
{
    public static float ConvertFromUserInput(float userInput)
    {
        if (userInput == 0)
        {
            return 1.0f;
        }

        float discountValue = 1 - userInput / 100;
        return (float)Math.Round(discountValue, 2);
    }
    public static float ConvertFromProduct(float productDiscount)
    {
        if (productDiscount == 1)
        {
            return 0f;
        }

        float discountPercentage = (1 - productDiscount) * 100;
        return (float)Math.Round(discountPercentage, 2);
    }
}
