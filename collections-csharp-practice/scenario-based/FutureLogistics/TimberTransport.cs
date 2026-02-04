public class TimberTransport : GoodsTransport
{
    private float timberLength;
    private float timberRadius;
    private string timberType;
    private float timberPrice;

    public TimberTransport(string transportId, string transportDate, int transportRating,
                           float timberLength, float timberRadius,
                           string timberType, float timberPrice)
        : base(transportId, transportDate, transportRating)
    {
        this.timberLength = timberLength;
        this.timberRadius = timberRadius;
        this.timberType = timberType;
        this.timberPrice = timberPrice;
    }

    public override string vehicleSelection()
    {
        double area = 2 * 3.147 * timberRadius * timberLength;

        if (area < 250) return "Truck";
        if (area <= 400) return "Lorry";
        return "MonsterLorry";
    }

    public override float calculateTotalCharge()
    {
        double volume = 3.147 * timberRadius * timberRadius * timberLength;
        double rate = timberType.Equals("Premium") ? 0.25 : 0.15;
        double price = volume * timberPrice * rate;

        double tax = price * 0.3;
        double discount = 0;

        if (transportRating == 5) discount = price * 0.20;
        else if (transportRating >= 3) discount = price * 0.10;

        double vehicleCost = vehicleSelection().Equals("Truck") ? 1000 :
                             vehicleSelection().Equals("Lorry") ? 1700 : 3000;

        return (float)((price + tax + vehicleCost) - discount);
    }
}
