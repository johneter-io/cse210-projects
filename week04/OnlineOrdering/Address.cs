class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // constructor
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // getters
    public string GetStreet() { return _street; }
    public string GetCity() { return _city; }
    public string GetState() { return _state; }
    public string GetCountry() { return _country; }

    // setters
    public void SetStreet(string street) { _street = street; }
    public void SetCity(string city) { _city = city; }
    public void SetState(string state) { _state = state; }
    public void SetCountry(string country) { _country = country; }

    // methods
    public bool IsInUSA()
    {
        return _country == "USA";
    }

    public string GetDisplayText()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}