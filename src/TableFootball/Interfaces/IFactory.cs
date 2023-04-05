namespace TableFootball.Interfaces
{
    using TableFootball.Data.Interfaces;

    public interface IFactory
    {
        IPlayerRepository GetPlayerRepository();
        IPlayerService GetPlayerService();
        IMatchRepository GetMatchRepository();
        ICalculateRankService GetCalculateRankService();
        ITrophyRepository GetTrophyRepository();
        ITrophyService GetTrophyService();
        IMatchMovementRepository GetMatchMovementRepository();
        IMatchMovementService GetMatchMovementService();
    }
}