Option Strict On
Option Explicit On 

namespace Objects

[Serializable()]
public class LoginCollection
Inherits System.Collections.CollectionBase

//Override constructor so that this object not publically creatable
public void New()
}

#region Add Methods"

public Function Add(string key) As LoginItem
return Add(key, "", -1)
}

public Function Add(string key, string text) As LoginItem
return Add(key, text, -1)
}

public Function Add(string key, string text, int index) As LoginItem

Dim newObject As New LoginItem()

If key != "" Then
//Error check that the new key does not exist
if (Contains(key)) {
throw new Exception(ErrorStringDuplicateKeyCollection)
}
newObject.SetKey(key)
else
key = newObject.Key
}

newObject.Text = text

//Error Check
key = Trim(key)
If key = "" Then
throw new Exception(ErrorStringNoKey)
else if (Contains(key)) {
throw new Exception(ErrorStringDuplicateKeyCollection)
}

try
//Create the object and add it to the collections
newObject.SetKey(key)
return AddObject(newObject, index)
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public Function AddObject(ByVal newObject As LoginItem) As LoginItem
return AddObject(newObject, -1)
}

public Function AddObject(ByVal newObject As LoginItem, int index) As LoginItem

//The object must be set and it must NOT have a parent
If newObject == null Then return null
If Not (newObject.Parent == null) Then
throw new Exception(ErrorStringObjectHasParent)
}

If (index < -1) || (index > Me.Count) Then
//Subscript out of range
throw new System.ArgumentOutOfRangeException()
}

If newObject.Key = "" Then newObject.Key = System.Guid.NewGuid().ToString

try
If index = -1 Then
base.List.Add(newObject)
else
base.List.Insert(index, newObject)
}
} catch (Exception ex) {
Globals.SetErr(ex);
}
newObject.SetParent(Me)

return newObject

}

#endregion

//Implementation of Exists property
public Function Contains(string key) As Boolean
Dim element As LoginItem
try
//Check the Key
foreach (element == this) {
If element.Key.Equals(key) Then
return true
}
}
//Check the Text
foreach (element == this) {
If StrComp(element.Text, key, CompareMethod.Text) = 0 Then
return true
}
}
return false
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public Function Contains(int index) As Boolean
return (0 <= index) AndAlso (index < Me.Count)
}

public Function Contains(ByVal value As LoginItem) As Boolean
Dim element As LoginItem
try
foreach (element == this) {
if (element == value) {
return true
}
}
return false
} catch (Exception ex) {
Globals.SetErr(ex);
}
}

Default public readonly Property Item(string key) As LoginItem
Get
try
Dim element As LoginItem

If IsNumeric(key) Then
return Item(CInt(key))
}

//Loop for Key
foreach (element == this) {
If element.Key.Equals(key) Then
return element
}
}
//Loop for Text
foreach (element == this) {
If StrComp(element.Text, key, CompareMethod.Text) = 0 Then
return element
}
}
} catch (Exception ex) {
Globals.SetErr(ex);
}
throw new System.ArgumentOutOfRangeException()
End Get
End Property

Default public readonly Property Item(int index) As LoginItem
Get
try
If (0 <= index) AndAlso (index < Me.Count) Then
return CType(base.List(index), LoginItem)
}
} catch (Exception ex) {
Globals.SetErr(ex);
}
throw new System.ArgumentOutOfRangeException()
End Get
End Property

public Function Remove(string key) As Boolean

try
Dim element As LoginItem
element = Item(key)
element.SetParent(null)
base.RemoveAt(element.Index)
return true
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public Shadows Function RemoveAt(int index) As Boolean

If Not Contains(index) Then
throw new System.ArgumentOutOfRangeException()
}

try
Dim element As LoginItem
element = Item(index)
element.SetParent(null)
base.RemoveAt(index)
return true
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public Function Remove(ByVal value As LoginItem) As Boolean

//Make sure that is has a parent
Dim index As Integer = value.Index
If index = 0 Then return false

//Make sure it is in this collection
If Not Contains(value) Then return false

//Remove the actial item
return RemoveAt(index)

}

public Function ToArray() As ArrayList

try
Dim array As ArrayList = New ArrayList()
Dim element As LoginItem
foreach (element == this) {
array.Add(element)
}
return array
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public void FromArray(ByVal array As ArrayList)

try
Dim o As Object
foreach o In array
Me.AddObject(CType(o, LoginItem))
}
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

#region XML"

public Function ToXML() As String

try
return ObjectToXML(Me.ToArray)
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public void FromXML(ByVal xml As String)

try
Me.Clear()
Me.FromArray(CType(XMLToObject(xml), ArrayList))
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public Function SaveXML(string fileName) As Boolean

try
return SaveXML(fileName, false)
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public Function SaveXML(string fileName, ByVal overWrite As Boolean) As Boolean

try

//Check for existence and remove if necessary
If System.IO.File.Exists(fileName) Then
If overWrite Then
System.IO.File.Delete(fileName)
else
//Do NOT overwrite. There == null to do
return false
}
}

SaveSoapToFile(fileName, Me.ToArray)
return true

} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public Function LoadXML(string fileName) As Boolean

try
If System.IO.File.Exists(fileName) Then
Me.FromArray(CType(LoadSoapFromFile(fileName), ArrayList))
}
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

#endregion

}

}
