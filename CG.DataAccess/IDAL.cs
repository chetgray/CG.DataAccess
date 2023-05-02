using System.Collections.Generic;
using System.Data;

namespace CG.DataAccess
{
    /// <summary>The data access between the data layer and the database.</summary>
    public interface IDAL
    {
        /// <summary>Executes a stored procedure with parameters.</summary>
        /// <param name="storedProcedureName">
        /// The name of the stored procedure to execute.
        /// </param>
        /// <param name="parameters">
        /// A dictionary of the parameters to pass to the stored procedure.
        /// </param>
        void ExecuteStoredProcedure(
            string storedProcedureName,
            IDictionary<string, object> parameters
        );

        /// <inheritdoc cref="ExecuteStoredProcedure"/>
        /// <summary>
        /// Executes a stored procedure with parameters, returning a single value.
        /// </summary>
        /// <returns>The single scalar value returned from the stored procedure.</returns>
        object GetValueFromStoredProcedure(
            string storedProcedureName,
            IDictionary<string, object> parameters
        );

        /// <inheritdoc cref="ExecuteStoredProcedure"/>
        /// <summary>
        /// Executes a stored procedure with parameters, returning a <see cref="DataTable"/>.
        /// </summary>
        /// <returns>
        /// The first <see cref="DataTable"/> in the result set returned from the stored
        /// procedure.
        /// </returns>
        DataTable GetTableFromStoredProcedure(
            string storedProcedureName,
            IDictionary<string, object> parameters
        );
    }
}
