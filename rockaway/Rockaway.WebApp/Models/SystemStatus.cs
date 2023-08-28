namespace Rockaway.WebApp.Models;

public class SystemStatus {
	public string? Message { get; set; }
	public DateTime? SystemTime { get; set; }

	public string AssemblyLocation { get; set; }

	public DateTime? AssemblyLastModified { get; set; }
	public string MachineName { get; set; }
	public string DatabaseServerStatus { get; set; }

}