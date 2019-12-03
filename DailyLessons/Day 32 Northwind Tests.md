# Day 32 - Northwind Tests

// tests
    
    
    #region TestNumberOfProductsStartingWithAndContainingAParticularLetter
    [TestCase(3)]
    public void TestNumberOfProductsStartingWithP(int expected)
    {
        // arrange (instance)
        var instance = new NorthwindProductTest();
        // act (method)
        var actual = instance.TestNumberOfProductsStartingWithP();
        // assert 
        Assert.AreEqual(expected, actual);
    }
    [TestCase("p",3)]
    public void TestNumberOfProductsStartingWithALetter(string letter, int expected)
    {
        // arrange (instance)
        var instance = new NorthwindProductTest();
        // act (method)
        var actual = instance.TestNumberOfProductsStartingWithALetter(letter);
        // assert 
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase("p", 17)]
    [TestCase("a", 58)]
    [TestCase("d", 30)]
    public void TestNumberOfProductsContainingALetter(string letter, int expected)
    {
        // arrange (instance)
        var instance = new NorthwindProductTest();
        // act (method)
        var actual = instance.TestNumberOfProductsContainingALetter(letter);
        // assert 
        Assert.AreEqual(expected, actual);
    }
    #endregion
    
    
    
    // solutions
    
    
    #region TestNumberOfProductsStartingWithAndContainingAParticularLetter
    public int TestNumberOfProductsStartingWithP()
    {
        using (var db = new Northwind())
        {
            string inputLetter = "p";
            var products1 =  db.Products.Where
                (p => 
                    p.ProductName.StartsWith("p") || 
                    p.ProductName.StartsWith("P"))
                .Count();
    
            var products = (
                from product in db.Products
                where product.ProductName.StartsWith("p")
                select product
                );
            var products2 =
                db.Products
                    .Where(p => 
                    p.ProductName.StartsWith(inputLetter.ToUpper()) || 
                    p.ProductName.StartsWith(inputLetter.ToLower()))
                    .Count();
            var products3 =
                db.Products.Where(p => p.ProductName.StartsWith(inputLetter))
                .Count();
            return products3;
        }
    }
    
    public int TestNumberOfProductsStartingWithALetter(string letter)
    {
        using (var db = new Northwind())
        {
            var productCount = 
                db.Products
                .Where(p => p.ProductName.StartsWith(letter))
                .Count();
            return productCount;
        }
    }
    
    public int TestNumberOfProductsContainingALetter(string letter)
    {
        using (var db = new Northwind())
        {
            var productCount =
                db.Products
                .Where(p => p.ProductName.Contains(letter))
                .Count();
            return productCount;
        }
    }
    #endregion