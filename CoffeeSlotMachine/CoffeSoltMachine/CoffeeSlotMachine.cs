/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: CoffeeSlotMachine
 *--------------------------------------------------------------
 */

namespace CoffeeSlotMachine;

public class CoffeeSlotMachine
{
    //TODO: Implement CoffeeSlot Object here
    //TODO: Constructors
    //TODO: private members
    //TODO: Properties
    //TODO: public Methods
    //TODO: private Methods
    //TODO: please use same name, parameter and return types as used in the unit-tests - you must not change the unit-tests.

    #region FieldVariables
    private const int   _price = 50; //Preis für jedes Produkt
    private string[]    _productsToOffer; //Jedes kaufbare Produkt
    private int[]       _validCoins = { 5, 10, 20, 50, 100, 200 }; //Auflistung der gültigen Münzen
    private int[]       _checkout; //Inhalt der Kassa (Anzahl von jeden Münzwert)
    private int[]       _productBoughtAmount = new int[3]; //Anzahl der gekaufen Produkten
    private int[]       _amountOfEachCoin = new int[6]; //Anzahl jede Münze zum Zeitpunkt der Einkauf (Noch nicht in Kassa)
    private int         _sumOfCurrentCoins = 0; //Gesamtbetrag der Münzen zum Zeitpunkt der Einkauf (Noch nicht im Kassa)
    #endregion

    #region Properties
    public int CoinsInDepot
    {
        get
        {
            int sum = 0;
            for (int i = 0; i < _checkout.Length; i++)
            {
                sum += _checkout[i];
            }
            return sum;
        }
    }
    public int ProductsAvailable
    {
        get { return _productsToOffer.Length; }
    }
    public int Credit
    {
        get { return _sumOfCurrentCoins; }
    }
    #endregion

    #region Constructors
    public CoffeeSlotMachine()
    {
        _checkout = new int[_validCoins.Length];
        for (int i = 0; i < _validCoins.Length; i++)
        {
            _checkout[i] = 3;
        }

        _productsToOffer = new string[] { "Cappucino", "Mocca", "Kakao" };
    }

    public CoffeeSlotMachine(int[] checkout, string[] products)
    {
        _checkout = checkout;
        _productsToOffer = products;
    }
    #endregion

    #region Methods
    public bool InsertCoin(int coin)
    {
        if (_sumOfCurrentCoins == 50 || !IsValidCoin(coin))
        {
            return false;
        }

        for (int i = 0; i < _validCoins.Length; i++)
        {
            if (coin == _validCoins[i])
            {
                _amountOfEachCoin[i]++;
                _sumOfCurrentCoins += coin;
            }
        }

        return true;
    }
    public bool SelectProduct(string productName, out int[] change, out int donated)
    {
        change = new int[_amountOfEachCoin.Length];
        donated = 0;

        if (_sumOfCurrentCoins < _price)
        {
            return false;
        }

        for (int i = 0; i < _productsToOffer.Length; i++)
        {
            if (productName == _productsToOffer[i])
            {
                _productBoughtAmount[i]++;

                for (int n = 0; n < _amountOfEachCoin.Length; n++)
                {
                    _checkout[n] += _amountOfEachCoin[n];
                }

                (change, donated) = GetChange(_sumOfCurrentCoins);

                ResetCustomerSession();

                return true;
            }
        }

        return false;
    }
    public int[] CancelOrder()
    {
        int[] outputArray = new int[_amountOfEachCoin.Length];

        for (int i = 0; i < _amountOfEachCoin.Length; i++)
        {
            outputArray[i] = _amountOfEachCoin[i];
            _amountOfEachCoin[i] = 0;
        }

        _sumOfCurrentCoins = 0;

        return outputArray;
    }
    public int EmptyDepot()
    {
        int output = 0;
        for (int i = 0; i < _checkout.Length; i++)
        {
            output += _checkout[i] * _validCoins[i];
            _checkout[i] = 0;
        }

        return output;
    }
    public bool GetCounterForProduct(string productName, out int amountSold)
    {
        amountSold = 0;

        for (int i = 0; i < _productBoughtAmount.Length; i++)
        {
            if (productName == _productsToOffer[i])
            {
                amountSold = _productBoughtAmount[i];
                return true;
            }
        }

        return false;
    }
    public bool GetCounterForCoin(int coin, out int amountOfCoins)
    {
        amountOfCoins = 0;

        for (int i = 0; i < _validCoins.Length; i++)
        {
            if (coin == _validCoins[i])
            {
                amountOfCoins = _checkout[i];
                return true;
            }
        }

        return false;
    }
    #endregion

    #region HelperMethod
    public bool IsValidCoin(int coin)
    {
        for (int i = 0; i < _validCoins.Length; i++)
        {
            if (coin == _validCoins[i])
            {
                return true;
            }
        }

        return false;
    }
    public void ResetCustomerSession()
    {
        for (int i = 0; i < _amountOfEachCoin.Length; i++)
        {
            _amountOfEachCoin[i] = 0;
        }

        _sumOfCurrentCoins = 0;
    }
    public (int[],int donate) GetChange(int amountReceived)
    {
        int[] changeToReturn = new int[_validCoins.Length];
        int change = amountReceived - _price;

        int i = _validCoins.Length - 1;

        while (change > 0 && i >= 0)
        {
            if (change >= _validCoins[i] && _checkout[i] > 0)
            {
                change -= _validCoins[i];
                changeToReturn[i]++;
                _checkout[i]--;
            }
            else
            {
                i--;
            }
        }

        return (changeToReturn, change);
    }
    #endregion
}