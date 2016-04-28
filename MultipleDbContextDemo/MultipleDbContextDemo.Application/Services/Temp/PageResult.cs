using System;
using System.Collections.Generic;
using System.Linq;
using MultipleDbContextDemo.Common;

namespace MultipleDbContextDemo.Application
{
    /// <summary>
    /// 分页组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T> where T : class
    {
        #region 属性

        /// <summary>
        /// 总条数
        /// </summary>
        public int DataCount { get; private set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; private set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int pageSize;
        private int PageSize
        {
            get { return pageSize; }
            set { pageSize = value < 1 ? 1 : value; }
        }

        /// <summary>
        /// 当前页数
        /// </summary>
        private int pageIndex;
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value < 1 ? 1 : value; }
        }

        /// <summary>
        /// 数据源
        /// </summary>
        public IEnumerable<T> DataSourse { private get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public Func<T, bool> Where { private get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public Func<T, int> OrderByField { private get; set; }

        /// <summary>
        /// 排序方式 DESC,ASC
        /// </summary>
        public OrderBy OrderByType { private get; set; }

        /// <summary>
        /// 返回当夜数据
        /// </summary>
        public IList<T> PageData { get; private set; }

        #endregion

        #region 构造
        public PageResult(IEnumerable<T> dataSourse)
        {
            this.PageSize = 20;
            this.PageIndex = 1;
            this.DataSourse = dataSourse;

            SetPageData();
        }
        public PageResult(int pageSize, int pageIndex, IEnumerable<T> dataSourse)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.DataSourse = dataSourse;

            SetPageData();
        }

        public PageResult(IEnumerable<T> dataSourse, Func<T, bool> where)
        {
            this.PageSize = 20;
            this.PageIndex = 1;
            this.DataSourse = dataSourse;
            this.Where = where;

            SetPageData();
        }
        public PageResult(int pageSize, int pageIndex, IEnumerable<T> dataSourse, Func<T, bool> where)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.DataSourse = dataSourse;
            this.Where = where;

            SetPageData();
        }

        public PageResult(IEnumerable<T> dataSourse, Func<T, bool> where, Func<T, int> orderByField)
        {
            this.PageSize = 20;
            this.PageIndex = 1;
            this.DataSourse = dataSourse;
            this.Where = where;
            this.OrderByField = orderByField;
            this.OrderByType = OrderBy.ASC;

            SetPageData();
        }

        public PageResult(int pageSize, int pageIndex, IEnumerable<T> dataSourse, Func<T, int> orderByField)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.DataSourse = dataSourse;
            this.OrderByField = orderByField;
            this.OrderByType = OrderBy.ASC;

            SetPageData();
        }
        public PageResult(int pageSize, int pageIndex, IEnumerable<T> dataSourse, Func<T, int> orderByField, OrderBy orderByType)
        {
            this.PageSize = 20;
            this.PageIndex = 1;
            this.DataSourse = dataSourse;
            this.OrderByField = orderByField;
            this.OrderByType = orderByType;

            SetPageData();
        }



        public PageResult(int pageSize, int pageIndex, IEnumerable<T> dataSourse, Func<T, bool> where, Func<T, int> orderByField)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.DataSourse = dataSourse;
            this.Where = where;
            this.OrderByField = orderByField;
            this.OrderByType = OrderBy.ASC;

            SetPageData();
        }
        public PageResult(IEnumerable<T> dataSourse, Func<T, bool> where, Func<T, int> orderByField, OrderBy orderByType)
        {
            this.PageSize = 20;
            this.PageIndex = 1;
            this.DataSourse = dataSourse;
            this.Where = where;
            this.OrderByField = orderByField;
            this.OrderByType = orderByType;

            SetPageData();
        }
        public PageResult(int pageSize, int pageIndex, IEnumerable<T> dataSourse, Func<T, bool> where, Func<T, int> orderByField, OrderBy orderByType)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.DataSourse = dataSourse;
            this.Where = where;
            this.OrderByField = orderByField;
            this.OrderByType = orderByType;

            SetPageData();
        }

        #endregion


        private void SetPageData()
        {
            int skipNum = this.PageIndex > 1 ? 0 : ((this.PageIndex - 1) * this.PageSize);

            this.DataCount = this.DataSourse.Count();
            this.PageCount = Convert.ToInt32(Math.Ceiling((double)this.DataCount / (double)this.PageSize));
            if (!this.Where.IsNull())
            {
                this.DataSourse = this.DataSourse.Where(this.Where);
            }
            this.DataSourse.Skip(skipNum).Take(this.PageSize);

            if (!this.OrderByField.IsNull() && !this.OrderByType.IsNull())
            {
                switch (this.OrderByType)
                {
                    case OrderBy.DESC:
                        this.DataSourse = this.DataSourse.OrderByDescending(this.OrderByField);
                        break;
                    case OrderBy.ASC:
                        this.DataSourse = this.DataSourse.OrderBy(this.OrderByField);
                        break;
                    default: break;
                }
            }

            PageData = this.DataSourse.ToList();
        }


    }
    /// <summary>
    /// 排序类型
    /// </summary>
    public enum OrderBy
    {
        DESC,
        ASC,
        NONE
    }
}
