class Customer
{
    private string _name;
    private Address _address;

    // constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // getters
    public string GetName() { return _name; }
    public Address GetAddress() { return _address; }

    // setters
    public void SetName(string name) { _name = name; }
    public void SetAddress(Address address) { _address = address; }

    // methods
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetDisplayText()
    {
        return $"{_name}\n{_address.GetDisplayText()}";
    }
}