# C-Sharp-CSV-Reader
C# CSV Reader

	// Example reading a CSV file
	// pass true if the csv contains a header so you can access columns by string

	using (CSV.CSVReader sr = new CSV.CSVReader("in.csv", true))
	{
		while (sr.ReadLine() == true)
		{
			Debugger.Log("The second column value is: " + sr.data[1] + " and " + sr.data["foo"]);
		}
	}



	// Example writing a CSV file

	Options data = new Options();
	data["first column"] = "abc";
	data["second column"] = "def";

	using(StreamWriter sw = new StreamWriter("out.csv"))
	{
		// Write the header
		sw.WriteLine(CSV.FormatCSV(data.GetKeys()));
		
		// Write the values
		sw.WriteLine(CSV.FormatCSV(data.GetValues()));
	}
