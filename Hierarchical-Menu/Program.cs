using System;
using Hierarchical_Menu.Models;

namespace Hierarchical_Menu
{
    class Program
    {

        static void Main(string[] args)
        {

            SubMenu userAdm = new SubMenu("User Admin");
            userAdm.SubMenus.Add(new MenuLeaf("Create User"));
            userAdm.SubMenus.Add(new MenuLeaf("Edit User"));

            SubMenu prodAdm = new SubMenu("product Admin");
            SubMenu allProd = new SubMenu("All Products");
            allProd.Add(new MenuLeaf("My Products"));
            prodAdm.Add(allProd);
            prodAdm.Add(new SubMenu("Create product"));
            SubMenu orderAdm = new SubMenu("Order Admin");
            orderAdm.Add(new SubMenu("Order Reports"));

            SubMenu orderReports = new SubMenu("Order Reports");
            orderReports.Add(new SubMenu("Audit Reports"));
            orderReports.SubMenus[0].Add(new MenuLeaf("Updated Orders"));
            orderReports.SubMenus[0].Add(new MenuLeaf("Created Orders"));
            orderAdm.Add(orderReports);
            orderAdm.Add(new MenuLeaf("Create Order"));

            //Declare menus
            SubMenu reports = new SubMenu("Reports");
            reports.Add(new SubMenu("Win Tech Report"));
            reports.Add(new SubMenu("Microsoft Report"));

            SubMenu admin = new SubMenu("Admin");

            admin.Add(userAdm);
            admin.Add(prodAdm);
            admin.Add(orderAdm);

            SubMenu TopLevelMenu = new SubMenu("Top");
            TopLevelMenu.Add(admin);
            TopLevelMenu.Add(reports);
            displayMenu(TopLevelMenu);
        }


        static void displayMenu(SubMenu menu)
        {
            //Display Recursively until no children or enter leaf

            menu.SubMenus.ForEach(subMenu =>
            {
                //First display current name then enter nested directly to display it
                Console.WriteLine("- " + subMenu.MenuName);
                displayRecursively((SubMenu)subMenu, 0);
            });
        }

        static void displayRecursively(SubMenu menu, int depth)
        {
            var indentation = string.Empty;
            char Tab = '\t';
            for (int i = 0; i <= depth; i++)
            {
                indentation += Tab;
            }
            //display name

            //check if contains children if so call this method 
            if (menu.SubMenus.Count != 0)
            {
                menu.SubMenus.ForEach(sub =>
                {
                    Console.WriteLine($"{indentation} - " + sub.MenuName);

                    //Important check if it is a leaf as it will throw error
                    if (sub.CanAddSubMenus() != false)
                        displayRecursively((SubMenu)sub, depth + 1);

                });

            }
        }
    }
}
