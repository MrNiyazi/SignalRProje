﻿namespace SignalRWebUI.Dtos.MessageDtos
{
	public class UpdateResultDto
	{
		public int MessageID { get; set; }
		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public string Phone { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public DateTime MessageSendData { get; set; }
		public bool Status { get; set; }
	}
}
