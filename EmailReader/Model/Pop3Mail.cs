using OpenPop.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pop3EmailReader.Model
{
	public class Pop3Mail
	{
		public int MessageNumber { get; set; }
		public Message Message { get; set; }
	}
}
