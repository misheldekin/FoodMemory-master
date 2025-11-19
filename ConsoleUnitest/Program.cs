using DBL;
using Models;
using Org.BouncyCastle.Crypto.Macs;
namespace ConsoleUnitest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //CustomerDB db = new CustomerDB();
            //Customers customer = new Customers();
            //customer.Name = "Tali";
            //customer.LastName = "Cohen";
            //customer.Email = "tali.cohen@gmail.com";
            //customer.Password = "tali123";
            //customer.IsAdmin = 0;
            //customer.ProfileImage = "tali.jpg";

            //customer = await db.InsertGetObjAsync(customer);
            //Console.WriteLine($"נוסף משתמש בהצלחה! ID: {customer.CustomerID}");

            //List<Customers> list = await db.GetAllAsync();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    await Console.Out.WriteLineAsync(@$"id={list[i].CustomerID}, name={list[i].Name} {list[i].LastName}, email={list[i].Email}, isAdmin={list[i].IsAdmin}, profileImage={list[i].ProfileImage}");
            //}
            //await Console.Out.WriteLineAsync("\n\n");

            //Customers loginUser = await db.LoginAsync("misheld@gmail.com", "mishel123");

            //if (loginUser != null)
            //{
            //    Console.WriteLine($"Login successful: {loginUser.Name} {loginUser.LastName}");
            //}
            //else
            //{
            //    Console.WriteLine(" Login failed!");
            //}

            //int rows1 = await db.UpdateFirstNameAsync(13, "Shahar");
            //if (rows1 > 0)
            //    Console.WriteLine("success");
            //else
            //    Console.WriteLine("Failed");

            //int rows2 = await db.UpdateLastNameAsync(13, "Hartstien");
            //if (rows2 > 0)
            //    Console.WriteLine("success");
            //else
            //    Console.WriteLine("Failed");

            //int rows3 = await db.UpdateEmailAsync(13, "shaharHart@icloud.com");
            //if (rows3 > 0)
            //    Console.WriteLine("success");
            //else
            //    Console.WriteLine("Failed");


            IngredientDB db = new IngredientDB();
            Ingredient ingredient = new Ingredient();
            //ingredient.IngredientName = "סודה";
            //ingredient = await db.InsertGetObjAsync(ingredient);
            //Console.WriteLine($"נוסף רכיב בהצלחה! ID: {ingredient.IngredientID}");

            //List<Ingredient> list = await db.GetAllAsync();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    await Console.Out.WriteLineAsync(@$"ID={list[i].IngredientID}, Name={list[i].IngredientName}");
            //}
            //await Console.Out.WriteLineAsync("\n\n");

            //List<Ingredient> results = await db.SearchIngredientsByNameAsync("סו");
            //for (int i = 0; i < results.Count; i++)
            //{
            //    Console.WriteLine($"ID={results[i].IngredientID}, Name={results[i].IngredientName}");
            //}


        }
    }
}
