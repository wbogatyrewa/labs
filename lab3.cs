/*
На основе одной из готовых обобщенных (шаблонных) объектных коллекций .NET создать класс
«Авиакомпания», включающий список самолетов. Классы самолетов должны образовывать
иерархию с базовым классом. Самолеты бывают двух типов: пассажирские и грузовые. Описать в
базовом классе абстрактный метод для расчета взлетного веса самолета. Для пассажирских
авиалайнеров взлетный вес – это количество мест на средний вес человека (62 кг.), для
грузовиков взлетный вес задается явно исходя из фактического веса груза, также взлетный вес
включает вес самого самолета, он определяется исходя из типа авиалайнера. В виде меню
программы реализовать нижеприведенный функционал.
1. Упорядочить всю последовательность авиалайнеров по возрастанию взлетного веса. При
совпадении взлетного веса – упорядочивать данные по номеру рейса. Вывести номер рейса, тип
самолета, список ФИО экипажа и взлетный вес для всех элементов списка.
2. Вывести первые 5 бортов из полученного в пункте 1 списка.
3. Вывести последние 3 номера рейса борта из полученного в пункте 1 списка.
4. В реальном времени (в процессе заполнения списка авиалайнеров) рассчитывать и
поддерживать в актуальном состоянии средний взлетный вес самолета по авиакомпании,
сохранить значение как поле класса «Авиакомпания».
5. Организовать запись и чтение всех данных в/из файла. Реализовать поддержку формата файлов
JSON.
6. Организовать обработку некорректного формата входного файла.
*/

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

namespace labs {
    
    class lab3 {
        static void Main3() {

        }
    }

    [XmlInclude(typeof(Cargo))]
    [XmlInclude(typeof(Passenger))]
    public abstract class Plane {
        public int flight { get; set; }
        public List<FIO> crew = new List<FIO>();
        public int weightOfPlane { get; set; }
        public abstract int TakeoffWeight();
    }
    public class Passenger : Plane {
        public string type = "Passenger";
        private int averageHumanWeight = 62;
        public int seat { get; set; } 
        public override int TakeoffWeight() {
            return seat * averageHumanWeight + weightOfPlane;
        }
    }
    public class Cargo : Plane {
        public string type = "Cargo";
        public int weightOfCargo { get; set; }
        public override int TakeoffWeight() {
            return weightOfCargo + weightOfPlane;
        }

    }

    public class FIO {
        public string firstName;
        public string lastName;
    }

    class Airline {
        public List<Plane> planes { get; set; } = new List<Plane>();
        
        public void AddPlane() {
            //planes.Add();
        }

        public void SortByWeight() {
            planes.OrderBy(plane => plane.TakeoffWeight()).ThenBy(plane => plane.flight);
        }

    }
}