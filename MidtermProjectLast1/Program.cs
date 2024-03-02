using System;

namespace Inventory
{
    class Owner
    {
        private string ID;
        private string Name;
        protected int issue;
        int defect = 0, expired = 0;
        public List<int> c = new List<int>() { 20, 20, 20, 20, 20, 20 };
        public List<int> t = new List<int>() { 20, 20, 20, };
        public List<int> d = new List<int>() { 20, 20, 20, };
        public List<int> m = new List<int>() { 20, 20, };

        public string id
        {
            get { return this.ID; }
            set { this.ID = value; }
        }
        public string name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        public Owner()
        {
            this.Name = "Ardale Retubado";
            this.ID = "0907";
        }
        public int OrderStock(int add, int ctr, List<string> condiments, List<string> toiletry, List<string> diaper, List<string> mosquito)
        {
            int order;
            do
            {
                Console.Write("Stocks ordered: ");
                order = int.Parse(Console.ReadLine());
                if (order < 0)
                {
                    Console.Write("Invalid order! Input a positive order."); Console.ReadKey(); Console.Clear();
                    int i = 1;
                    switch (add)
                    {
                        case 1:
                            Console.WriteLine("\n----Condiments----\n");
                            foreach (string y in condiments)
                                Console.WriteLine("{0} - " + y, i++); break;
                        case 2:
                            Console.WriteLine("\n----Toiletry----\n");
                            foreach (string y in toiletry)
                                Console.WriteLine("{0} - " + y, i++); break;
                        case 3:
                            Console.WriteLine("\n----Diaper----\n");
                            foreach (string y in diaper)
                                Console.WriteLine("{0} - " + y, i++); break;
                        case 4:
                            Console.WriteLine("\n----Mosquito Repellent----\n");
                            foreach (string y in mosquito)
                                Console.WriteLine("{0} - " + y, i++); break;
                    }
                    Console.WriteLine("\nSelect which product do you wish to order: {0}", ctr);
                }
            } while (order < 0);
            return order;
        }
        public int Hotoy(int add, int ctr, int order)
        {
            if (add == 1)
                return c[ctr - 1] += order;
            if (add == 2)
                return t[ctr - 1] += order;
            if (add == 3)
                return d[ctr - 1] += order;
            if (add == 4)
                return m[ctr - 1] += order;
            else
                return 0;
        }
        public int Ord(int order, List<int> pay)
        {
            int x = 0;
            x = pay[0] += order;
            return x;
        }
        public int Hotoy(int add, int ctr, int order, int diff)
        {
            if (add == 1)
                return c[ctr - 1] -= order;
            if (add == 2)
                return t[ctr - 1] -= order;
            if (add == 3)
                return d[ctr - 1] -= order;
            if (add == 4)
                return m[ctr - 1] -= order;
            else
                return 0;
        }

        public int SellStock(int add, int ctr, List<string> condiments, List<string> toiletry, List<string> diaper, List<string> mosquito)
        {
            int order;
            do
            {
                Console.Write("Stocks sold: ");
                order = int.Parse(Console.ReadLine());
                if (order < 0)
                {
                    Console.Write("Invalid number!."); Console.ReadKey(); Console.Clear();
                    int i = 1;
                    switch (add)
                    {
                        case 1:
                            Console.WriteLine("\n----Condiments----\n");
                            foreach (string y in condiments)
                                Console.WriteLine("{0} - " + y, i++); break;
                        case 2:
                            Console.WriteLine("\n----Toiletry----\n");
                            foreach (string y in toiletry)
                                Console.WriteLine("{0} - " + y, i++); break;
                        case 3:
                            Console.WriteLine("\n----Diaper----\n");
                            foreach (string y in diaper)
                                Console.WriteLine("{0} - " + y, i++); break;
                        case 4:
                            Console.WriteLine("\n----Mosquito Repellent----\n");
                            foreach (string y in mosquito)
                                Console.WriteLine("{0} - " + y, i++); break;
                    }
                    Console.WriteLine("\nSelect which product was sold: {0}", ctr);
                }
            } while (order < 0);

            return order;
        }
        public void MakePayment(float price, int order)
        {
            float payment = price * order;
            Console.WriteLine("\nTotal payment for the order is {0}", payment.ToString("0.00"));
        }
        public float MakePayment(int opt, float price, int order, List<float> pay)
        {
            if (opt == 1)
            {
                float payment = price * order;
                float total = pay[0] += payment;
                return total;
            }
            else
            {
                float payment = price * order;
                float total = pay[1] += payment;
                return total;
            }
        }
        public void IssueReport(string product)
        {
            Console.WriteLine("\nEnter quality issue of {0}", product);
            Console.WriteLine("Options: "); Console.WriteLine("1 - Defect"); Console.WriteLine("2 - Expired");
            Console.Write("\nIssue no.: ");
            issue = int.Parse(Console.ReadLine());

            switch (issue)
            {
                case 1: defect++; break;
                case 2: expired++; break;
            }

            Console.WriteLine("\nThis issue has been registered in the system.");
            List<string> reports = new List<string>();
            reports.Add(product);
            Console.WriteLine("\nProducts reported: ");
            foreach (string x in reports) Console.WriteLine("-" + x);
        }

        public void ReportQualityIssues()
        {
            Console.WriteLine("\nIssues reported:");
            Console.WriteLine("Defect/s - {0}, Expired - {1}", defect, expired);
        }

        public void ShowStock(List<string> condiments, List<string> toiletry, List<string> diaper, List<string> mosquito)
        {
            Console.WriteLine("Condiment products - Stock\n");
            var cond = condiments.Zip(c, (n, w) => new { produ = n, price = w });
            foreach (var nw in cond)
                Console.WriteLine("- " + nw.produ + " - " + nw.price + " pcs");

            Console.WriteLine("\nToiletry products - Stock\n");
            var toilet = toiletry.Zip(t, (n, w) => new { produ = n, price = w });
            foreach (var nw in toilet)
                Console.WriteLine("- " + nw.produ + " - " + nw.price + " pcs");

            Console.WriteLine("\nDiaper products - Stock \n");
            var dia = diaper.Zip(d, (n, w) => new { produ = n, price = w });
            foreach (var nw in dia)
                Console.WriteLine("- " + nw.produ + " - " + nw.price + " pcs");

            Console.WriteLine("\nMosquito repellent products - Stock\n");
            var mos = mosquito.Zip(m, (n, w) => new { produ = n, price = w });
            foreach (var nw in mos)
                Console.WriteLine("- " + nw.produ + " - " + nw.price + " pcs");
        }
    }

    class OrderDetails : Owner
    {
        private string productID;
        private int NoOfProducts;
        private float Amount;

        public string prodid
        {
            get { return this.productID; }
            set { this.productID = value; }
        }

        public int NoOfProduct
        {
            get { return this.NoOfProducts; }
            set { this.NoOfProducts = value; }
        }

        public float amount
        {
            get { return this.Amount; }
            set { this.Amount = value; }
        }

        public void ShowOrderDetails(int opt)
        {
            if (opt == 1)
            {
                Console.WriteLine("\nProduct ID: {0}", productID);
                Console.WriteLine("No. of products in cart: {0}", NoOfProducts);
                Console.WriteLine("\nTotal amount to be paid: {0}\n", Amount.ToString("0.00"));
            }
            else
            {
                Console.WriteLine("\nProduct ID: {0}", productID);
                Console.WriteLine("Total amount received: {0}\n", Amount.ToString("0.00"));
            }
        }
    }

    class Product
    {
        string name, expdate;
        private float price;
        private string id;
        public string Name
        {
            get { return this.name; } set { this.name = value; }
        }
        public float Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public string Exp
        {
            get { return this.expdate; }
            set { this.expdate = value; }
        }
        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public void AddProducts(int x, List<string> condiments, List<string> toiletry, List<string> diaper, List<string> mosquito, List<string> puno)
        {
            if (x == 1)
            {
                condiments.Add(Name);
                puno.Add(id);
                Console.WriteLine("\nUpdated list of condiments: ");
                foreach (string y in condiments)
                    Console.WriteLine(y);
            }
            if (x == 2)
            {
                toiletry.Add(name); puno.Add(id);
                Console.WriteLine("\nUpdated list of toiletry: ");
                foreach (string y in toiletry)
                    Console.WriteLine(y);
            }
            if (x == 3)
            {
                diaper.Add(name); puno.Add(id);
                Console.WriteLine("\nUpdated list of diaper: ");
                foreach (string y in diaper)
                    Console.WriteLine(y);
            }
            if (x == 4)
            {
                mosquito.Add(name); puno.Add(id);
                Console.WriteLine("\nUpdated list of mosquito repellent: ");
                foreach (string y in mosquito)
                    Console.WriteLine(y);
            }
        }

        public void DeleteProducts(int x, List<string> condiments, List<string> toiletry, List<string> diaper, List<string> mosquito)
        {
            switch (x)
            {
                case 1:
                    condiments.Remove(name);
                    Console.WriteLine("\nUpdated list of condiments: ");
                    foreach (string y in condiments)
                        Console.WriteLine(y); break;
                case 2:
                    toiletry.Remove(name);
                    Console.WriteLine("\nUpdated list of toiletry: ");
                    foreach (string y in toiletry)
                        Console.WriteLine(y); break;
                case 3:
                    diaper.Remove(name);
                    Console.WriteLine("\nUpdated list of removed: ");
                    foreach (string y in diaper)
                        Console.WriteLine(y); break;
                case 4:
                    mosquito.Remove(name);
                    Console.WriteLine("\nUpdated list of mosquito repellent: ");
                    foreach (string y in mosquito)
                        Console.WriteLine(y); break;
            }
        }
        public void ShowProducts(int x, List<string> toiletry, List<string> diaper, List<string> mosquito, List<float> price1, List<float> price2, List<float> price3, List<string> t, List<string> d, List<string> m)
        {
            int i = 0;
            switch (x)
            {
                case 2:
                    Console.WriteLine("Product ID - Toiletry products - Price");
                    var toilet = toiletry.Zip(price1, (n, w) => new { produ = n, price = w });
                    foreach (var nw in toilet)
                    {
                        Console.Write("{0} - ", t[i]); i++;
                        Console.WriteLine(nw.produ + " - " + nw.price.ToString("0.00"));
                    }

                    Console.WriteLine("\nProduct ID - Diaper products - Price ");
                    var dia = diaper.Zip(price2, (n, w) => new { produ = n, price = w }); i = 0;
                    foreach (var nw in dia)
                    {
                        Console.Write("{0} - ", d[i]); i++;
                        Console.WriteLine(nw.produ + " - " + nw.price.ToString("0.00"));
                    }


                    Console.WriteLine("\nProduct ID - Mosquito repellent products - Price \n");
                    var mos = mosquito.Zip(price3, (n, w) => new { produ = n, price = w }); i = 0;
                    foreach (var nw in mos)
                    {
                        Console.Write("{0} - ", m[i]); i++;
                        Console.WriteLine(nw.produ + " - " + nw.price.ToString("0.00"));
                    }
                    break;
                default:
                    Console.Write("Invalid input!"); break;
            }
        }
        public void ShowProducts(int x, List<string> expdate, List<string> condiments, List<float> priceA, List<string> ID)
        {
            int i = 0;
            if (x == 1)
            {
                Console.WriteLine("Condiment products - Price \n");
                var conds = condiments.Zip(priceA, (n, w) => new { produ = n, price = w });
                foreach (var nw in conds)
                {
                    Console.Write("{0} - ", ID[i]);
                    Console.WriteLine(nw.produ + " - " + nw.price.ToString("0.00"));
                    i++;
                }
                Console.WriteLine();
                Console.WriteLine("\nBest before:");
                var condi = condiments.Zip(expdate, (n, w) => new { prod = n, exp = w });
                foreach (var nw in condi)
                    Console.WriteLine(nw.prod + " - " + nw.exp);
            }
        }
    }

    static class Def
    {
        public static void menu()
        {
            Console.WriteLine("----Main menu----");
            Console.WriteLine("\n1 - Stock management"); Console.WriteLine("2 - Product"); Console.WriteLine("\n0 - Exit");
            Console.Write("\nChoose an option: ");
        }
        public static int back()
        {
            int z;
            Console.Write("\nPress 1 to go back to Main Menu or press 0 to Exit: ");
            z = int.Parse(Console.ReadLine());

            return z;
        }

        public static void choice()
        {
            int t = Def.back();
            Console.Clear();

            if (t == 0)
                Def.exit();
        }
        public static void exit()
        {
            Console.WriteLine("Good bye!");
            Environment.Exit(0);
        }

        public static int Sho(int opt, int add, List<string> condiments, List<string> toiletry, List<string> diaper, List<string> mosquito)
        {
            int ctr, q;
            do
            {
                int i = 1; Console.Clear();
                if (add == 1)
                {
                    Console.WriteLine("\n----Condiments----\n");
                    foreach (string y in condiments)
                        Console.WriteLine("{0} - " + y, i++);
                }
                else if (add == 2)
                {
                    Console.WriteLine("\n----Toiletry----\n");
                    foreach (string y in toiletry)
                        Console.WriteLine("{0} - " + y, i++);
                }
                else if (add == 3)
                {
                    Console.WriteLine("\n----Diaper----\n");
                    foreach (string y in diaper)
                        Console.WriteLine("{0} - " + y, i++);
                }
                else if (add == 4)
                {
                    Console.WriteLine("\n----Mosquito Repellent----\n");
                    foreach (string y in mosquito)
                        Console.WriteLine("{0} - " + y, i++);
                }

                else
                {
                    Console.WriteLine("Invalid input!"); Console.Write("Enter any number to choose between Main Menu or Exit: ");
                }

                if (opt == 1 && add <= 4 && add > 0)
                {
                    Console.Write("\nSelect which product do you wish to order: ");
                }
                else if (opt == 2 && add <= 4 && add > 0)
                {
                    Console.Write("\nSelect which product was sold: ");
                }

                ctr = int.Parse(Console.ReadLine());
                q = i;
                if (ctr < 1 || ctr >= i)
                {
                    if (add > 4)
                    {
                        ctr = 0; break;
                    }
                    else
                    {
                        Console.Write("Invalid input. Try again! "); Console.ReadKey(); Console.Clear();
                        if (add == 1)
                        {
                            i = 0;
                            Console.WriteLine("\n----Condiments----\n");
                            foreach (string y in condiments)
                                Console.WriteLine("{0} - " + y, i++);
                        }

                        else if (add == 2)
                        {
                            i = 0;
                            Console.WriteLine("\n----Toiletry----\n");
                            foreach (string y in toiletry)
                                Console.WriteLine("{0} - " + y, i++);
                        }
                        else if (add == 3)
                        {
                            i = 0;
                            Console.WriteLine("\n----Diaper----\n");
                            foreach (string y in diaper)
                                Console.WriteLine("{0} - " + y, i++);
                        }
                        else if (add == 4)
                        {
                            i = 0;
                            Console.WriteLine("\n----Mosquito Repellent----\n");
                            foreach (string y in mosquito)
                                Console.WriteLine("{0} - " + y, i++);
                        }
                    }
                }
            } while (ctr < 1 || ctr >= q);
            return ctr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string user, id;

            Owner verify = new Owner();

            do
            {
                Console.WriteLine("----Welcome to Mabaso's Store Inventory----");
                Console.WriteLine();
                Console.Write("Enter username: ");
                user = Console.ReadLine();

                if (String.Equals(user, verify.name) == false)
                {
                    Console.WriteLine("\nNo such username is registered in the system. Please use a verified account.\n");
                    Console.Write("Press any key to try again.");
                    Console.ReadKey(); Console.Clear();
                }
            } while (String.Equals(user, verify.name) == false);

            do
            {
                Console.Write("Enter ID: ");
                id = Console.ReadLine();

                if (String.Equals(id, verify.id) == false)
                {
                    Console.WriteLine("\nIncorrect ID.\n"); Console.Write("Press any key to try again.");
                    Console.ReadKey(); Console.Clear();
                    Console.WriteLine("----Welcome to Mabaso's Store Inventory----");
                    Console.WriteLine();
                    Console.WriteLine("Enter username: {0}", verify.name);
                }
            } while (String.Equals(id, verify.id) == false);
            Console.Clear();

            OrderDetails prod = new OrderDetails();
            Product product = new Product();

            int option, add, opt, ctr, order;
            List<int> wa = new List<int>() { 0 };
            List<float> pay = new List<float>() { 0, 0 };
            List<string> condiments = new List<string>() { "Magic Sarap", "Ginisa Mix", "Vitsen", "Aji Oyster Sauce", "Crispy fry (small)", "Crispy fry (big)" };
            List<string> toiletry = new List<string>() { "Bioderm (Blue)", "Bioderm (Bloom Pink)", "Safeguard (Yellow)" };
            List<string> diaper = new List<string>() { "Medium", "Large", "Xtra-Large" };
            List<string> mosquito = new List<string>() { "Baygon", "Lion Tiger" };
            List<string> cID = new List<string>() { "A111", "A112", "A113", "A114", "A115", "A116" };
            List<string> tID = new List<string>() { "T001", "T002", "T003" };
            List<string> dID = new List<string>() { "D101", "D102", "D103" };
            List<string> mID = new List<string>() { "M001", "M002" };
            List<float> priceA = new List<float>() { 5.00F, 5.00F, 4.00F, 6F, 11F, 20F };
            List<float> price1 = new List<float>() { 25.00F, 25.00F, 18.00F };
            List<float> price2 = new List<float>() { 9.00F, 10.00F, 11.00F };
            List<float> price3 = new List<float>() { 3.00F, 2.50F };
            List<string> expdate = new List<string>() { "12/27/24", "12/12/25", "11/17/23", "09/05/23", "02/02/24", "07/13/23" };

            do
            {
                Def.menu();
                option = int.Parse(Console.ReadLine());
                Console.Clear();

                if (option == 0)
                {
                    Def.exit();
                }

                else if (option == 1)
                {
                    Console.WriteLine("----Stock management----");
                    Console.WriteLine("\n1 - Order Stock"); Console.WriteLine("2 - Sold Stock"); Console.WriteLine("3 - Issue Report"); Console.WriteLine("4 - Show Stock");
                    Console.Write("\nChoose an option: ");
                    opt = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (opt)
                    {
                        case 1:
                            Console.WriteLine("----Order Stock----");
                            Console.WriteLine("\n1 - Condiments"); Console.WriteLine("2 - Toiletry"); Console.WriteLine("3 - Diaper"); Console.WriteLine("4 - Mosquito Repellent/s");
                            Console.Write("\nChoose which product to order: ");
                            add = int.Parse(Console.ReadLine()); Console.Clear();

                            ctr = Def.Sho(opt, add, condiments, toiletry, diaper, mosquito);
                            if (ctr == 0)
                                break;
                            order = prod.OrderStock(add, ctr, condiments, toiletry, diaper, mosquito);
                            prod.Hotoy(add, ctr, order);

                            switch (add)
                            {
                                case 1:
                                    //ORDER DETAILS
                                    prod.prodid = cID[ctr - 1];
                                    prod.NoOfProduct = prod.Ord(order, wa);
                                    prod.amount = prod.MakePayment(opt, priceA[ctr - 1], order, pay);
                                    prod.MakePayment(priceA[ctr - 1], order); prod.ShowOrderDetails(opt); break;

                                case 2:
                                    prod.prodid = tID[ctr - 1];
                                    prod.NoOfProduct = prod.Ord(order, wa);
                                    prod.amount = prod.MakePayment(opt, price1[ctr - 1], order, pay);
                                    prod.MakePayment(price1[ctr - 1], order);
                                    prod.ShowOrderDetails(opt); break;
                                case 3:
                                    prod.prodid = dID[ctr - 1];
                                    prod.NoOfProduct = prod.Ord(order, wa);
                                    prod.amount = prod.MakePayment(opt, price2[ctr - 1], order, pay);
                                    prod.MakePayment(price2[ctr - 1], order);
                                    prod.ShowOrderDetails(opt); break;

                                case 4:
                                    prod.prodid = mID[ctr - 1];
                                    prod.NoOfProduct = prod.Ord(order, wa);
                                    prod.amount = prod.MakePayment(opt, price3[ctr - 1], order, pay);
                                    prod.MakePayment(price3[ctr - 1], order);
                                    prod.ShowOrderDetails(opt); break;

                                default:
                                    Console.WriteLine("\nNo assigned category for that choice!"); break;
                            }
                            break;

                        case 2:
                            Console.WriteLine("----Sold Stock----");
                            Console.WriteLine("\n1 - Condiments"); Console.WriteLine("2 - Toiletry"); Console.WriteLine("3 - Diaper"); Console.WriteLine("4 - Mosquito Repellent/s");
                            Console.Write("\nChoose which product to sell: ");
                            add = int.Parse(Console.ReadLine()); Console.Clear();

                            ctr = Def.Sho(opt, add, condiments, toiletry, diaper, mosquito);
                            if (ctr < 1) break;
                            order = prod.SellStock(add, ctr, condiments, toiletry, diaper, mosquito);

                            switch (add)
                            {
                                case 1:
                                    if (order <= prod.c[ctr - 1])
                                    {
                                        prod.Hotoy(add, ctr, order, 1);
                                        prod.prodid = cID[ctr - 1];
                                        prod.amount = prod.MakePayment(opt, priceA[ctr - 1], order, pay);
                                        prod.ShowOrderDetails(opt);
                                    }
                                    else
                                        Console.WriteLine("\nERROR! Stock sold exceeded the stock available. Stock available: {0}", prod.c[ctr - 1]);
                                    break;
                                case 2:
                                    if (order <= prod.t[ctr - 1])
                                    {
                                        prod.Hotoy(add, ctr, order, 1);
                                        prod.prodid = tID[ctr - 1];
                                        prod.amount = prod.MakePayment(opt, price1[ctr - 1], order, pay);
                                        prod.ShowOrderDetails(opt);
                                    }
                                    else
                                        Console.WriteLine("\nERROR! Stock sold exceeded the stock available. Stock available: {0}", prod.t[ctr - 1]);
                                    break;
                                case 3:
                                    if (order <= prod.d[ctr - 1])
                                    {
                                        prod.Hotoy(add, ctr, order, 1);
                                        prod.prodid = dID[ctr - 1];
                                        prod.amount = prod.MakePayment(opt, price2[ctr - 1], order, pay);
                                        prod.ShowOrderDetails(opt);
                                    }
                                    else
                                        Console.WriteLine("\nERROR! Stock sold exceeded the stock available. Stock available: {0}", prod.d[ctr - 1]);
                                    break;

                                case 4:
                                    if (order <= prod.m[ctr - 1])
                                    {
                                        prod.Hotoy(add, ctr, order, 1);
                                        prod.prodid = mID[ctr - 1];
                                        prod.amount = prod.MakePayment(opt, price3[ctr - 1], order, pay);
                                        prod.ShowOrderDetails(opt);
                                    }
                                    else
                                        Console.WriteLine("\nERROR! Stock sold exceeded the stock available. Stock available: {0}", prod.m[ctr - 1]);
                                    break;

                                default:
                                    Console.WriteLine("No assigned category for that choice!"); break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("----Issue Report----\n");
                            Console.Write("\nEnter product with issue: ");
                            string issue = Console.ReadLine();

                            prod.IssueReport(issue);
                            prod.ReportQualityIssues(); break;
                        case 4:
                            Console.WriteLine("----Show Stock----"); Console.WriteLine();
                            prod.ShowStock(condiments, toiletry, diaper, mosquito); break;
                    }
                }

                else if (option == 2)
                {
                    Console.WriteLine("----Product----");
                    Console.WriteLine("\n1 - Add Product/s"); Console.WriteLine("2 - Delete Product/s"); Console.WriteLine("3 - Show Product/s");
                    Console.Write("\nChoose an option: ");
                    opt = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (opt)
                    {
                        case 1:
                            Console.WriteLine("----Add Product/s----");
                            Console.WriteLine("\n1 - Condiments"); Console.WriteLine("2 - Toiletry"); Console.WriteLine("3 - Diaper"); Console.WriteLine("4 - Mosquito Repellent/s");
                            Console.Write("\nChoose which category to add: ");
                            add = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            switch (add)
                            {
                                case 1:
                                    Console.Write("Type the product to be added: ");
                                    product.Name = Console.ReadLine();
                                    Console.Write("\nEnter product ID (A11): ");
                                    product.ID = Console.ReadLine();
                                    Console.Write("Enter product price: ");
                                    product.Price = float.Parse(Console.ReadLine()); priceA.Add(product.Price);
                                    Console.Write("Enter expiration date (mm/dd/yy): "); prod.c.Add(0);
                                    product.Exp = Console.ReadLine(); expdate.Add(product.Exp);
                                    product.AddProducts(add, condiments, toiletry, diaper, mosquito, cID);
                                    break;
                                case 2:
                                    Console.Write("Type the product to be added: ");
                                    product.Name = Console.ReadLine();
                                    Console.Write("\nEnter product ID (T00): ");
                                    product.ID = Console.ReadLine();
                                    Console.Write("Enter product price: ");
                                    product.Price = float.Parse(Console.ReadLine()); price1.Add(product.Price); prod.t.Add(0);
                                    product.AddProducts(add, condiments, toiletry, diaper, mosquito, tID);
                                    break;
                                case 3:
                                    Console.Write("Type the product to be added: ");
                                    product.Name = Console.ReadLine();
                                    Console.Write("\nEnter product ID (D10): ");
                                    product.ID = Console.ReadLine();
                                    Console.Write("Enter product price: ");
                                    product.Price = float.Parse(Console.ReadLine()); price2.Add(product.Price); prod.d.Add(0);
                                    product.AddProducts(add, condiments, toiletry, diaper, mosquito, dID);
                                    break;
                                case 4:
                                    Console.Write("Type the product to be added: ");
                                    product.Name = Console.ReadLine();
                                    Console.Write("\nEnter product ID (M00): ");
                                    product.ID = Console.ReadLine();
                                    Console.Write("Enter product price: ");
                                    product.Price = float.Parse(Console.ReadLine()); price3.Add(product.Price); prod.m.Add(0);
                                    product.AddProducts(add, condiments, toiletry, diaper, mosquito, mID);
                                    break;
                            }
                            break;

                        case 2:
                            Console.WriteLine("----Delete Product/s----");
                            Console.WriteLine("\n1 - Condiments"); Console.WriteLine("2 - Toiletry"); Console.WriteLine("3 - Diaper"); Console.WriteLine("4 - Mosquito Repellent/s");
                            Console.Write("\nChoose which product to delete: ");
                            add = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            switch (add)
                            {
                                case 1:
                                    Console.WriteLine("List of existing products: ");
                                    foreach (string y in condiments)
                                        Console.WriteLine(y);

                                    Console.WriteLine("\nType the product to be removed: ");
                                    product.Name = Console.ReadLine();
                                    product.DeleteProducts(add, condiments, toiletry, diaper, mosquito);
                                    break;
                                case 2:
                                    Console.WriteLine("List of existing products: ");
                                    foreach (string y in toiletry)
                                        Console.WriteLine(y);
                                    Console.WriteLine("\nType the product to be removed: ");
                                    product.Name = Console.ReadLine();
                                    product.DeleteProducts(add, condiments, toiletry, diaper, mosquito);
                                    break;
                                case 3:
                                    Console.WriteLine("List of existing products: ");
                                    foreach (string y in diaper)
                                        Console.WriteLine(y);
                                    Console.WriteLine("\nType the product to be removed: ");
                                    product.Name = Console.ReadLine();
                                    product.DeleteProducts(add, condiments, toiletry, diaper, mosquito); break;
                                case 4:
                                    Console.WriteLine("List of existing products: ");
                                    foreach (string y in mosquito)
                                        Console.WriteLine(y);
                                    Console.WriteLine("\nType the product to be removed: ");
                                    product.Name = Console.ReadLine();
                                    product.DeleteProducts(add, condiments, toiletry, diaper, mosquito);
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("----Show Products----");
                            Console.WriteLine("\n1 - With Expiration Dates"); Console.WriteLine("2 - Without Expiration Dates");
                            Console.Write("\nChoose which products to show: ");
                            add = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            switch (add)
                            {
                                case 1:
                                    product.ShowProducts(add, expdate, condiments, priceA, cID); break;
                                case 2:
                                    product.ShowProducts(add, toiletry, diaper, mosquito, price1, price2, price3, tID, dID, mID); break;
                            }
                            break;
                    }
                }
                Def.choice();
            } while (option != 0);
        }
    }
}