using System;
using System.Linq;

namespace InvoiceObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            /* (Querying an Array of Invoice Objects) Use the class Invoice provided in the ex09_03 folder
            with this chapter’s examples to create an array of Invoice objects. Use the sample data shown in
            ig. 9.8. Class Invoice includes four properties—a PartNumber (type int), a PartDescription (type
            string), a Quantity of the item being purchased (type int) and a Price (type decimal). Perform
            the following queries on the array of Invoice objects and display the results:
            a) Use LINQ to sort the Invoice objects by PartDescription.
            b) Use LINQ to sort the Invoice objects by Price.
            c) Use LINQ to select the PartDescription and Quantity and sort the results by
            Quantity. 
            d) Use LINQ to select from each Invoice the PartDescription and the value of the Invoice
            (i.e., Quantity * Price). Name the calculated column InvoiceTotal. Order the
            results by Invoice value. [Hint: Use let to store the result of Quantity * Price in a new
            range variable total.]
            e) Using the results of the LINQ query in part (d), select the InvoiceTotals in the range
            $200 to $500.*/


            //Initiate array of invoices
            Invoice[] invoices =
            {
                new Invoice(83, "Electric Sander", 7, 57.98M),
                new Invoice(24, "Power Saw", 18, 99.99M),
                new Invoice(7, "Sledge Hammer", 11, 21.5M),
                new Invoice(77, "Hammer", 76, 11.99M),
                new Invoice(39, "Lawn Mower", 3, 79.5M),
                new Invoice(68, "Screwdriver", 106, 6.99M),
                new Invoice(56, "Jig Saw", 21, 11M),
                new Invoice(3, "Wrench", 34, 7.5M),
            };


            //a) Use LINQ to sort the Invoice objects by PartDescription.
            var sortedByDescription =
                from item in invoices
                orderby item.PartDescription
                select item;

            //display invoices, sorted by description
            Console.WriteLine("Sorted by description:");
            foreach (var item in sortedByDescription)
            {
                Console.WriteLine(item);
            }


            //b) Use LINQ to sort the Invoice objects by Price.
            var sortedByPrice =
                from item in invoices
                orderby item.Price
                select item;

            //display invoices, sorted by Price
            Console.WriteLine("Sorted by price:");
            foreach (var item in sortedByPrice)
            {
                Console.WriteLine(item);
            }


            //c) Use LINQ to select the PartDescription and Quantity and sort the results by Quantity.
            var DescriptionAndQuantity =
                from item in invoices
                orderby item.Quantity
                select new { item.PartDescription, item.Quantity };

            //display invoices, sorted by quantity
            Console.WriteLine("Sorted by quantity:");
            foreach (var item in DescriptionAndQuantity)
            {
                Console.WriteLine(item);
            }


            /* d) Use LINQ to select from each Invoice the PartDescription and the value of the Invoice
            (i.e., Quantity * Price). Name the calculated column InvoiceTotal. Order the
            results by Invoice value. [Hint: Use let to store the result of Quantity * Price in a new
            range variable total.] */
            var descriptionAndTotal =
                from item in invoices
                let total = item.Quantity * item.Price
                orderby total
                select new { item.PartDescription, InvoiceTotal = total };

            //display description and calculated invoice total
            Console.WriteLine("\nSelect description and Invoice Total, Sort by total");
            foreach (var item in descriptionAndTotal)
            {
                Console.WriteLine(item);
            }


            //e) Using the results of the LINQ query in part (d), select the InvoiceTotals in the range $200 to $500.
            var totalbw200and500 =
                from item in descriptionAndTotal
                where item.InvoiceTotal > 200M && item.InvoiceTotal < 500M
                select item;

            // display filtererd desccriptions and invoices
            Console.WriteLine("\nInvoice totals between {200:C} and {500:C}:");
            foreach (var item in totalbw200and500)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}
