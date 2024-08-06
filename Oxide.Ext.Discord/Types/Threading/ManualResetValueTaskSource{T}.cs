﻿using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Oxide.Ext.Discord.Types;

internal class ManualResetValueTaskSource<T> : IValueTaskSource<T>
{
    private ManualResetValueTaskSourceCore<T> _taskSource;

    public short Version => _taskSource.Version;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal ValueTask<T> GetTask() => new(this, _taskSource.Version);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void SetResult(T result) => _taskSource.SetResult(result);
        
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void SetException(Exception ex) => _taskSource.SetException(ex);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void Reset() => _taskSource.Reset();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetResult(short token) => _taskSource.GetResult(token);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTaskSourceStatus GetStatus(short token) => _taskSource.GetStatus(token);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags) => _taskSource.OnCompleted(continuation, state, token, flags);
}