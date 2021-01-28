using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWarsSharp.Patterns.Builder {
    class Builder {
        public Builder() {
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());
        }
    }

    /// <summary>
    /// абстрактный класс строителя
    /// </summary>
    abstract class BreadBuilder {
        public Bread Bread { get; private set; }
        public void CreateBread() {
            Bread = new Bread();
        }
        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }

    /// <summary>
    /// пекарь
    /// </summary>
    class Baker {
        public Bread Bake(BreadBuilder breadBuilder) {
            breadBuilder.CreateBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }

    /// <summary>
    /// строитель для ржаного хлеба
    /// </summary>
    class RyeBreadBuilder: BreadBuilder {
        public override void SetFlour() {
            this.Bread.Flour = new Flour { Sort = "Ржаная мука 1 сорт" };
        }

        public override void SetSalt() {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives() {
            // не используется
        }
    }

    /// <summary>
    /// строитель для пшеничного хлеба
    /// </summary>
    class WheatBreadBuilder: BreadBuilder {
        public override void SetFlour() {
            this.Bread.Flour = new Flour { Sort = "Пшеничная мука высший сорт" };
        }

        public override void SetSalt() {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives() {
            this.Bread.Additives = new Additives { Name = "улучшитель хлебопекарный" };
        }
    }

    /// <summary>
    /// мука
    /// </summary>
    class Flour {
        /// <summary>
        /// какого сорта мука
        /// </summary>
        public string Sort { get; set; }
    }

    /// <summary>
    /// соль
    /// </summary>
    class Salt { }

    /// <summary>
    /// пищевые добавки
    /// </summary>
    class Additives {
        public string Name { get; set; }
    }

    class Bread {
        /// <summary>
        /// мука
        /// </summary>
        public Flour Flour { get; set; }
        /// <summary>
        /// соль
        /// </summary>
        public Salt Salt { get; set; }
        /// <summary>
        /// пищевые добавки
        /// </summary>
        public Additives Additives { get; set; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            if (Flour != null)
                sb.Append(Flour.Sort + "\n");
            if (Salt != null)
                sb.Append("Соль \n");
            if (Additives != null)
                sb.Append("Добавки: " + Additives.Name + " \n");
            return sb.ToString();
        }
    }
}
