using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Easy.Domain.Application;
using Easy.ServiceDemo.Api.Models;

namespace Easy.ServiceDemo.Api.Controller
{
    public class DemoController:ApiController
    {
        [HttpGet]
        public ResultWithData<string> SayHello(string name,int age)
        {
            return new ResultWithData<string>(200,string.Format("你好，我是：{0}，今年{1}岁 -- {2}",name,age,DateTime.Now));
        }

        [HttpPost]
        public ResultWithData<Student> GetStudentInfo(Person person)
        {
            return new ResultWithData<Student>(200,new Student()
            {
                Id=person.Id,Name = person.Name,Age = person.Age,Class ="一班",Height = 180.1f,Occupation = "学生",School = "北京大学",Score = 100,Weight = 70.4f
            });
        }

    }
}
