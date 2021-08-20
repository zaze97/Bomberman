/// <summary>
/// FSM状态机 切换行为状态基类
/// </summary>
public abstract class EnemyBaseState
{
    /// <summary>
    /// 开始状态
    /// </summary>
    /// <param name="enemy"></param>
    public abstract void EnterStart(Enemy enemy);

    /// <summary>
    /// 一直更新的状态
    /// </summary>
    /// <param name="enemy"></param>
    public abstract void OnUpdate(Enemy enemy);
}
