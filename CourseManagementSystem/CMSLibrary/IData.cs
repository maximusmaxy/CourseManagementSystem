using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    interface IData
    {
        /// <summary>
        /// Adds the data to the database.
        /// </summary>
        /// <returns>Whether the update was successful.</returns>
        bool Add();

        /// <summary>
        /// Updates the data in the database.
        /// </summary>
        /// <returns>Whether the update was successful.</returns>
        bool Update();

        /// <summary>
        /// Deletes the data from the database.
        /// </summary>
        /// <returns>Whether the delete was successful.</returns>
        bool Delete();

        /// <summary>
        /// Searches the data from the database.
        /// </summary>
        /// <returns>Whether the search was successful.</returns>
        bool Search();
    }
}
