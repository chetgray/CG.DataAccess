# CG.DataAccess namespace

| public type | description |
| --- | --- |
| class [DAL](#dal-class) | The data access between the data layer and the database. (Implements [IDAL](#idal-interface))
| interface [IDAL](#idal-interface) | The data access between the data layer and the database. |

## DAL class

```csharp
public class DAL : IDAL
```

### Public Members

| name | description |
| --- | --- |
| [DAL](#dal-constructor)(…) | Initializes a new instance of the [`DAL`](#dal-class) class with the passed *connectionString*. |
| [ExecuteStoredProcedure](#idalexecutestoredprocedure-method)(…) | Executes a stored procedure with parameters. (Inherited from [IDAL](#idal-interface)) |
| [GetValueFromStoredProcedure](#idalgetvaluefromstoredprocedure-method)(…) | Executes a stored procedure with parameters, returning a single value. (Inherited from [IDAL](#idal-interface)) |
| [GetTableFromStoredProcedure](#idalgettablefromstoredprocedure-method)(…) | Executes a stored procedure with parameters, returning a DataTable. (Inherited from [IDAL](#idal-interface)) |

### DAL constructor

Initializes a new instance of the [`DAL`](#dal-class) class with the passed *`connectionString`*.

```csharp
public DAL(string connectionString)
```

| parameter | description |
| --- | --- |
| connectionString | The connection string to use for any `SqlConnection`. |

#### Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | Thrown when the passed *`connectionString`* is `null`. |

## IDAL interface

The data access between the data layer and the database.

```csharp
public interface IDAL
```

### Members

| name | description |
| --- | --- |
| [ExecuteStoredProcedure](#idalexecutestoredprocedure-method)(…) | Executes a stored procedure with parameters. |
| [GetValueFromStoredProcedure](#idalgetvaluefromstoredprocedure-method)(…) | Executes a stored procedure with parameters, returning a single value. |
| [GetTableFromStoredProcedure](#idalgettablefromstoredprocedure-method)(…) | Executes a stored procedure with parameters, returning a DataTable. |

### IDAL.ExecuteStoredProcedure method

Executes a stored procedure with parameters.

```csharp
public void ExecuteStoredProcedure(
    string storedProcedureName, 
    IDictionary<string, object> parameters
)
```

| parameter | description |
| --- | --- |
| storedProcedureName | The name of the stored procedure to execute. |
| parameters | A dictionary of the parameters to pass to the stored procedure. |

### IDAL.GetValueFromStoredProcedure method

Executes a stored procedure with parameters, returning a single value.

```csharp
public object GetValueFromStoredProcedure(
    string storedProcedureName, 
    IDictionary<string, object> parameters
)
```

#### Return Value

The single scalar value returned from the stored procedure.

### IDAL.GetTableFromStoredProcedure method

Executes a stored procedure with parameters, returning a `DataTable`.

```csharp
public DataTable GetTableFromStoredProcedure(
    string storedProcedureName,
    IDictionary<string, object> parameters
)
```

#### Return Value

The first `DataTable` in the result set returned from the stored
procedure.
