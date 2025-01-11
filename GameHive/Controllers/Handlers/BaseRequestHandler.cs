// <copyright file="BaseRequestHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers;

using GameHive.Helpers;
using GameHive.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a base class for request handlers.
/// </summary>
/// <typeparam name="TRequest">The type of the request object.</typeparam>
public abstract class BaseRequestHandler<TRequest>
    where TRequest : IRequest
{
    private readonly ILogger logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRequestHandler{TRequest}"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    protected BaseRequestHandler(ILogger logger)
    {
        this.logger = logger;
    }

    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request">The request object.</param>
    /// <returns>The action result.</returns>
    public async Task<IActionResult> Handle(TRequest request)
    {
        try
        {
            return await this.HandleRequest(request);
        }
        catch (Exception e)
        {
            return this.HandleError(ConstantValues.InternalServerError, e);
        }
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected abstract Task<IActionResult> HandleRequest(TRequest request);

    /// <summary>
    /// Handles a not found request.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <param name="args">Additional arguments for the log message.</param>
    /// <returns>The action result.</returns>
    protected IActionResult HandleNotFound(string message, params object[] args)
    {
        this.logger.LogWarning(message, args);
        return new NotFoundObjectResult(string.Format(message, args));
    }

    /// <summary>
    /// Handles a successful request.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <param name="result">The result object.</param>
    /// <param name="args">Additional arguments for the log message.</param>
    /// <returns>The action result.</returns>
    protected IActionResult HandleSuccess(string message, object? result = null, params object[] args)
    {
        this.logger.LogInformation(message, args);
        return result != null
            ? new OkObjectResult(result)
            : new OkResult();
    }

    /// <summary>
    /// Handles an error request.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <param name="ex">The exception.</param>
    /// <param name="args">Additional arguments for the log message.</param>
    /// <returns>The action result.</returns>
    protected IActionResult HandleError(string message, Exception ex, params object[] args)
    {
        this.logger.LogError(ex, message, args);
        return new StatusCodeResult(StatusCodes.Status500InternalServerError);
    }

    /// <summary>
    /// Handles a bad request.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <param name="args">Additional arguments for the log message.</param>
    /// <returns>The action result.</returns>
    protected IActionResult HandleBadRequest(string message, params object[] args)
    {
        this.logger.LogWarning(message, args);
        return new BadRequestObjectResult(string.Format(message, args));
    }

    /// <summary>
    /// Handles a bad request validation.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <param name="obj">The validation message.</param>
    /// <param name="args">Additional arguments for the log message.</param>
    /// <returns>The action result.</returns>
    protected IActionResult HandleBadRequestValidation(string message, object obj, params object[] args)
    {
        this.logger.LogWarning(message, args);
        return new BadRequestObjectResult(obj);
    }

    /// <summary>
    /// Handles an unauthorized request.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <param name="args">Additional arguments for the log message.</param>
    /// <returns>The action result.</returns>
    protected IActionResult HandleUnauthorized(string message, params object[] args)
    {
        this.logger.LogWarning(message, args);
        return new UnauthorizedResult();
    }

    /// <summary>
    /// Handles a forbidden request.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <param name="args">Additional arguments for the log message.</param>
    /// <returns>The action result.</returns>
    protected IActionResult HandleForbidden(string message, params object[] args)
    {
        this.logger.LogWarning(message, args);
        return new ForbidResult();
    }

    /// <summary>
    /// Handles a response for a new resource that has been created.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <param name="value">The value of the created resource.</param>
    /// <param name="uri">The URI of the created resource.</param>
    /// <param name="args">The log message arguments.</param>
    /// <returns>The <see cref="CreatedResult"/> object.</returns>
    protected IActionResult HandleCreated(string message, object value, string uri = "", params object[] args)
    {
        this.logger.LogInformation(message, args);
        return new CreatedResult(uri, value);
    }
}