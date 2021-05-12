using System;
using System.Collections.Generic;

namespace Hierarchical_Menu.Models
{
    abstract class Menu
    {
        public string MenuName { get; set; }
        public Menu() { }
        public Menu(string name)
        {
            MenuName = name;
        }
        public abstract string operation();

        public virtual void Add(Menu menu)
        {

        }

        public virtual void Remove(Menu menu)
        {

        }

        public virtual bool CanAddSubMenus()
        {
            return true;
        }

    }


    class MenuLeaf : Menu
    {
        //This classed cannot have any children!
        private string MenuFunction { get; set; }
        public MenuLeaf(string name)
        {
            MenuName = name;
        }
        public override string operation()
        {
            return MenuFunction;
        }
        public override bool CanAddSubMenus()
        {
            return false;
        }
    }

    class SubMenu : Menu
    {
        //Class storing reference to the nested children
        public List<Menu> SubMenus = new List<Menu>();
        public SubMenu(string name)
        {
            MenuName = name;
        }
        public override void Add(Menu subMenu)
        {
            this.SubMenus.Add(subMenu);

        }

        public override void Remove(Menu menu)
        {
            this.SubMenus.Remove(menu);
        }
        public override string operation()
        {
            return "Can have more than 1 Operation";
        }
    }
}
