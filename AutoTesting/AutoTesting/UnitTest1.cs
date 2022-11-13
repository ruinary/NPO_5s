using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace AutoTesting
{
    public class Tests
    {
        private IWebDriver driver;

        //Test1
        private readonly By searchBar = By.Name("q");
        private readonly By searchButton = By.ClassName("material-icons");

        //Test2
        private readonly By addToCompareCatalogItem1 = By.XPath("//a[@class='add-to compare-1168']");
        private readonly By addToCompareCatalogItem2 = By.XPath("//a[@class='add-to compare-1169']");
        private readonly By nameOfCompareItem = By.XPath("//a[@class='color-site']");

        //Test3
        private readonly By cartPageButton = By.ClassName("basket-top-new");

        //Test4
        private readonly By addToFavoriteCatalogItem1 = By.XPath("//a[@class='add-to favorites-1168']");
        private readonly By addToFavoriteCatalogItem2 = By.XPath("//a[@class='add-to favorites-1169']");
        private readonly By nameOfFavoriteItem = By.XPath("//a[@class='color-site']");

        //Test5
        private readonly By topBar1 = By.ClassName("sub-head");
        private readonly By topBar2 = By.XPath("//div[@class='outer-block nav-outer-block-2']");
        private readonly By topBar3 = By.XPath("//div[@class='background - site outer-block block-navigation-2']"); 
        private readonly By translateToEN = By.LinkText("EN");

        //Test7
        private readonly By catalogItems = By.XPath("//div[@class='catalog-item']");

        //Test9
        private readonly By lastViewProducts = By.ClassName("last-viewed-products");
        private readonly By moreInfoCatalogItem = By.XPath("//a[@class='more-info-product button2']");

        //Test10
        private readonly By rangeFrom = By.XPath("//input[@class='filter-inputs-inp range-from']");
        private readonly By rangeTo = By.XPath("//input[@class='filter-inputs-inp range-to']");
        private readonly By filterButton = By.ClassName("filter-notice");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://shop-alesyaoao.by/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            String searchText = "Платье";

            driver.FindElement(searchBar).Clear();
            driver.FindElement(searchBar).SendKeys(searchText);
            driver.FindElement(searchButton).Click();

            Console.WriteLine("Page title is: " + driver.Title);
            Console.WriteLine("Page title is: " + driver.Title);

            Assert.That(driver.Title, Is.EqualTo("Результаты поиска по запросу \"" + searchText + "\""));
        }

        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://shop-alesyaoao.by/catalog/genskiy-trikotag");

            driver.FindElement(addToCompareCatalogItem1).Click();
            driver.FindElement(addToCompareCatalogItem2).Click();

            driver.Navigate().GoToUrl("https://shop-alesyaoao.by/compare");

            var compareItems = driver.FindElements(nameOfCompareItem);

            Console.WriteLine("Added items to compare: " + compareItems.Count);
            Console.WriteLine("Total added items to compare: " + 2);

            Assert.That((compareItems.Count), Is.EqualTo(2));
        }

        [Test]
        public void Test3()
        {
            driver.FindElement(cartPageButton).Click();

            var compareItems = driver.FindElements(nameOfCompareItem);

            Console.WriteLine("Browser URL: " + driver.Url);

            Assert.That((driver.Url), Is.EqualTo("https://shop-alesyaoao.by/cart"));
        }

        [Test]
        public void Test4()
        {
            driver.Navigate().GoToUrl("https://shop-alesyaoao.by/catalog/genskiy-trikotag");

            driver.FindElement(addToFavoriteCatalogItem1).Click();
            driver.FindElement(addToFavoriteCatalogItem2).Click();

            driver.Navigate().GoToUrl("https://shop-alesyaoao.by/favorites");

            var favoriteItems = driver.FindElements(nameOfFavoriteItem);

            Console.WriteLine("Added items to favorite: " + (favoriteItems.Count));
            Console.WriteLine("Total added items to favorite: " + 2);

            Assert.That((favoriteItems.Count), Is.EqualTo(2));
        }

        [Test]
        public void Test5()
        {
            bool flag = true;
            driver.FindElement(translateToEN).Click();
            var topBarItems1 = driver.FindElements(topBar1);
            var topBarItems2 = driver.FindElements(topBar2);
            var topBarItems3 = driver.FindElements(topBar3);
            for (int i = 0; i < topBarItems1.Count; i++)
            {
                if (!Regex.IsMatch(topBarItems1[i].Text, @"^[А-Яа-я0-9]+[[\s]*[А-Яа-я0-9]*]*$"))
                {
                    flag = false;
                }

                if (flag == false)
                {
                    break;
                }
            }
            if (flag == true)
            {
                for (int i = 0; i < topBarItems2.Count; i++)
                {
                    if (!Regex.IsMatch(topBarItems2[i].Text, @"^[А-Яа-я0-9]+[[\s]*[А-Яа-я0-9]*]*$"))
                    {
                        flag = false;
                    }

                    if (flag == false)
                    {
                        break;
                    }
                }
            }
            else if (flag == true)
            {
                for (int i = 0; i < topBarItems3.Count; i++)
                {
                    if (!Regex.IsMatch(topBarItems3[i].Text, @"^[А-Яа-я0-9]+[[\s]*[А-Яа-я0-9]*]*$"))
                    {
                        flag = false;
                    }

                    if (flag == false)
                    {
                        break;
                    }
                }
            }
            Assert.That((flag), Is.EqualTo(true));
        }

        [Test]
        public void Test7()
        {
            String searchText = "";

            driver.FindElement(searchBar).Clear();
            driver.FindElement(searchBar).SendKeys(searchText);
            driver.FindElement(searchButton).Click();

            Console.WriteLine("Found items: " + (driver.FindElements(catalogItems)).Count());

            Assert.That((driver.FindElements(catalogItems)).Count(), Is.EqualTo(0));
        }

        [Test]
        public void Test9()
        {
            bool flag = false;
            driver.Navigate().GoToUrl("https://shop-alesyaoao.by/catalog/genskiy-trikotag");
            (driver.FindElements(moreInfoCatalogItem))[0].Click();
            driver.Navigate().GoToUrl("https://shop-alesyaoao.by/catalog/genskiy-trikotag");

            if (driver.FindElement(lastViewProducts) != null) flag = true;
            Assert.That(flag, Is.EqualTo(true));
        }

        [Test]
        public void Test10()
        {
            driver.Navigate().GoToUrl("https://shop-alesyaoao.by/catalog/genskiy-trikotag");

            driver.FindElement(rangeTo).Clear();
            driver.FindElement(rangeTo).SendKeys("0");

            driver.FindElement(rangeFrom).Clear();
            driver.FindElement(rangeFrom).SendKeys("0");

            driver.FindElement(filterButton).Click();

            Console.WriteLine("Found items: " + (driver.FindElements(catalogItems)).Count());

            Assert.That((driver.FindElements(catalogItems)).Count(), Is.EqualTo(0));
        }

    }
}