﻿using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Gentings.Data;
using Gentings.Extensions.Internal;

namespace Gentings.Extensions
{
    /// <summary>
    /// 对象管理基类。
    /// </summary>
    /// <typeparam name="TModel">当前模型实例。</typeparam>
    /// <typeparam name="TKey">唯一键类型。</typeparam>
    public abstract class ObjectManager<TModel, TKey> : ObjectManagerBase<TModel, TKey>, IObjectManager<TModel, TKey>
        where TModel : IIdObject<TKey>
    {
        /// <summary>
        /// 分页获取实例列表。
        /// </summary>
        /// <typeparam name="TQuery">查询实例类型。</typeparam>
        /// <param name="query">查询实例。</param>
        /// <param name="countExpression">返回总记录数的表达式,用于多表拼接过滤重复记录数。</param>
        /// <returns>返回分页实例列表。</returns>
        public virtual IPageEnumerable<TModel> Load<TQuery>(TQuery query,
            Expression<Func<TModel, object>> countExpression = null) where TQuery : QueryBase<TModel>
        {
            return Context.Load(query, countExpression);
        }

        /// <summary>
        /// 分页获取实例列表。
        /// </summary>
        /// <typeparam name="TObject">返回的对象模型类型。</typeparam>
        /// <typeparam name="TQuery">查询实例类型。</typeparam>
        /// <param name="query">查询实例。</param>
        /// <param name="countExpression">返回总记录数的表达式,用于多表拼接过滤重复记录数。</param>
        /// <returns>返回分页实例列表。</returns>
        public virtual IPageEnumerable<TObject> Load<TQuery, TObject>(TQuery query,
            Expression<Func<TModel, object>> countExpression = null) where TQuery : QueryBase<TModel>
        {
            return Context.Load<TQuery, TObject>(query, countExpression);
        }

        /// <summary>
        /// 分页获取实例列表。
        /// </summary>
        /// <typeparam name="TQuery">查询实例类型。</typeparam>
        /// <param name="query">查询实例。</param>
        /// <param name="countExpression">返回总记录数的表达式,用于多表拼接过滤重复记录数。</param>
        /// <param name="cancellationToken">取消标识。</param>
        /// <returns>返回分页实例列表。</returns>
        public virtual Task<IPageEnumerable<TModel>> LoadAsync<TQuery>(TQuery query,
            Expression<Func<TModel, object>> countExpression = null, CancellationToken cancellationToken = default)
            where TQuery : QueryBase<TModel>
        {
            return Context.LoadAsync(query, countExpression, cancellationToken);
        }

        /// <summary>
        /// 分页获取实例列表。
        /// </summary>
        /// <typeparam name="TObject">返回的对象模型类型。</typeparam>
        /// <typeparam name="TQuery">查询实例类型。</typeparam>
        /// <param name="query">查询实例。</param>
        /// <param name="countExpression">返回总记录数的表达式,用于多表拼接过滤重复记录数。</param>
        /// <param name="cancellationToken">取消标识。</param>
        /// <returns>返回分页实例列表。</returns>
        public virtual Task<IPageEnumerable<TObject>> LoadAsync<TQuery, TObject>(TQuery query,
            Expression<Func<TModel, object>> countExpression = null, CancellationToken cancellationToken = default)
            where TQuery : QueryBase<TModel>
        {
            return Context.LoadAsync<TQuery, TObject>(query, countExpression, cancellationToken);
        }

        /// <summary>
        /// 初始化类<see cref="ObjectManager{TModel,TKey}"/>。
        /// </summary>
        /// <param name="context">数据库操作实例。</param>
        protected ObjectManager(IDbContext<TModel> context) : base(context)
        {
        }
    }

    /// <summary>
    /// 对象管理实现基类。
    /// </summary>
    /// <typeparam name="TModel">模型类型。</typeparam>
    public abstract class ObjectManager<TModel> : ObjectManager<TModel, int>, IObjectManager<TModel>
        where TModel : IIdObject
    {
        /// <summary>
        /// 初始化类<see cref="ObjectManager{TModel}"/>。
        /// </summary>
        /// <param name="context">数据库操作实例。</param>
        protected ObjectManager(IDbContext<TModel> context) : base(context)
        {
        }
    }
}