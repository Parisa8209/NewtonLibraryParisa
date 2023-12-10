using NewtonLibraryParisa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonLibraryParisa.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace NewtonLibraryParisa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Context context = new Context())
            {
                DataAccess dataAccess = new DataAccess(context);
                dataAccess.Seed();
                dataAccess.RunMenu();
                
                //dataAccess.Recreate();



            }

        }
    }
}
    
    

