using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceryWeb.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return @"  ______                                                                        
 /      \                                                                       
/$$$$$$  |  ______   __    __   ______    _______   ______    ______   __    __ 
$$ \__$$/  /      \ /  |  /  | /      \  /       | /      \  /      \ /  |  /  |
$$      \ /$$$$$$  |$$ |  $$ |/$$$$$$  |/$$$$$$$/ /$$$$$$  |/$$$$$$  |$$ |  $$ |
 $$$$$$  |$$ |  $$ |$$ |  $$ |$$ |  $$/ $$ |      $$    $$ |$$ |  $$/ $$ |  $$ |
/  \__$$ |$$ \__$$ |$$ \__$$ |$$ |      $$ \_____ $$$$$$$$/ $$ |      $$ \__$$ |
$$    $$/ $$    $$/ $$    $$/ $$ |      $$       |$$       |$$ |      $$    $$ |
 $$$$$$/   $$$$$$/   $$$$$$/  $$/        $$$$$$$/  $$$$$$$/ $$/        $$$$$$$ |
                                                                      /  \__$$ |
                                                                      $$    $$/ 
                                                                       $$$$$$/  ";
        }
    }
}