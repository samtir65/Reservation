﻿namespace ReservationSystem.Domain.Models.Reservations
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
        Reservation GetBy(int Id);
    }
}