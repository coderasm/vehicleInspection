using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using Inspection.Models;

namespace Inspection.DataAccess
{
    public class FlooredCarFlatDAO : FlooredCarFlatRepository
    {
        private readonly BaseRepository<FlooredCarFlat> _internalBaseRepository;
        private readonly DateTime defaultDate = DateTime.Parse("1899-12-30 00:00:00.000");
        private readonly Expression<Func<FlooredCarFlat, bool>> getAllFlooredPredicate;

        private const string getAllNeverInspectedQuery = @"SELECT DISTINCT c.ACCOUNTNO, c.COMPANY FROM ABSContact..CONTACT1 c
                                                            JOIN GSV g ON c.ACCOUNTNO = g.DealerID
                                                            JOIN fin_vehicles fv ON g.VehicleID = fv.VehicleID
                                                            LEFT JOIN Fin_Inspections fi ON fv.VehicleID = fi.VehicleID
                                                            WHERE
	                                                            fi.VehicleID IS NULL AND
	                                                            (fv.FundsRecd is NULL OR fv.FundsRecd = '1899-12-30 00:00:00.000') AND
	                                                            fv.FlooringDate IS NOT NULL AND
	                                                            fv.FlooringDate <> '1899-12-30 00:00:00.000'";

        public FlooredCarFlatDAO(BaseRepository<FlooredCarFlat> _internalBaseRepository)
        {
            this._internalBaseRepository = _internalBaseRepository;
            getAllFlooredPredicate = car => isFloored(car);
        }

        private bool isFloored(FlooredCarFlat car)
        {
            return (car.FundsRecd == null || car.FundsRecd.Equals(defaultDate)) &&
                   car.FlooringDate != null && !car.FlooringDate.Equals(defaultDate);
        }

        public async Task<List<FlooredCarFlat>> getAll()
        {
            return await _internalBaseRepository.FindBy(getAllFlooredPredicate);
        }


        public async Task<FlooredCarFlat> getById(int id)
        {
            return await _internalBaseRepository.getById(id);
        }

        public async Task<List<FlooredCarFlat>> getAllNeverInspected()
        {
            using (var connection = await ConnectionFactory.getOpenConnection())
            {
                var neverInspectedCars = await connection.QueryAsync<FlooredCarFlat>(getAllNeverInspectedQuery);
                return neverInspectedCars.ToList();
            }
        }

        public Task<List<FlooredCarFlat>> getAllByRegion(int regionId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<FlooredCarFlat>> getAllByDealer(int dealerId)
        {
            throw new System.NotImplementedException();
        }
    }
}