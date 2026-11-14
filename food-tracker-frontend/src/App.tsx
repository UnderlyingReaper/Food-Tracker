import { useEffect, useState } from "react";
import { BudgetAPI } from "./api/BudgetApi";
import type { BudgetDashboard } from "./types/budget";

function App() {
  const [dashboard, setDashboard] = useState<BudgetDashboard | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchDashboard = async () => {
      try {
        setLoading(true);
        const data = await BudgetAPI.getDashboard();
        setDashboard(data);
      } catch (err) {
        setError("Could not connect to the C# Backend. Is it running & is CORS enabled?");
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchDashboard();
  }, []);

  // 3. Early Returns: Handle Loading, Error, and Empty DB states first
  if (loading) {
    return (
      <div className="min-h-screen bg-slate-50 flex items-center justify-center text-slate-600 font-medium">
        Loading your budget from backend...
      </div>
    );
  }

  if (error) {
    return (
      <div className="min-h-screen bg-slate-50 flex items-center justify-center p-6">
        <div className="bg-red-50 border border-red-200 text-red-700 p-6 rounded-xl max-w-md">
          <h2 className="font-bold text-lg mb-2">Connection Error</h2>
          <p className="text-sm">{error}</p>
        </div>
      </div>
    );
  }
  
  if (!dashboard) {
    return (
      <div className="min-h-screen bg-slate-50 flex items-center justify-center p-6">
        <div className="bg-white border border-slate-200 p-6 rounded-xl shadow-sm text-center">
          <h2 className="text-xl font-bold text-slate-800 mb-2">No Budget Found</h2>
          <p className="text-slate-500 text-sm">Create a budget in Swagger first, or we can add the Create form next!</p>
        </div>
      </div>
    );
  }

  const monthlyPercentUsed = Math.min(
    100,
    Math.round((dashboard.spentThisMonth / dashboard.monthlyBudget) * 100)
  );
  const dailyPercentUsed = Math.min(
    100,
    Math.round((dashboard.spentToday / dashboard.fixedDailyBudget) * 100)
  );

  return (
    <div className="min-h-screen bg-slate-50 text-slate-900 p-8 font-sans">
      <div className="max-w-5xl mx-auto space-y-6">
        
        {/* Header */}
        <div className="flex items-center justify-between">
          <div>
            <div className="flex items-center gap-3">
              <h1 className="text-3xl font-bold tracking-tight">Dashboard</h1>
              <span className="bg-emerald-100 text-emerald-700 text-xs font-semibold px-2.5 py-1 rounded-full">
                Active Cycle
              </span>
            </div>
            <p className="text-sm text-slate-500 mt-1">Live data from ASP.NET Core API</p>
          </div>
        </div>

        {/* Top 3 Stat Cards */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          
          {/* Card 1: Dynamic Daily Target */}
          <div className="bg-white border-t-4 border-t-emerald-600 border border-slate-200 rounded-xl p-5 shadow-xs">
            <div className="flex justify-between items-center mb-3">
              <span className="text-xs font-semibold uppercase tracking-wider text-slate-500">
                Dynamic Daily Target
              </span>
              <span className="text-xs bg-emerald-50 text-emerald-700 px-2 py-0.5 rounded font-medium">
                Safe Pace
              </span>
            </div>
            <div className="text-3xl font-bold text-emerald-600">
              Rs. {dashboard.dynamicDailyBudget.toLocaleString()}
              <span className="text-sm font-normal text-slate-400"> / day</span>
            </div>
            <p className="text-xs text-emerald-600 font-medium mt-3">
              Rs. {dashboard.dynamicRemainingToday.toLocaleString()} left on dynamic pace today
            </p>
          </div>

          {/* Card 2: Fixed Daily Budget */}
          <div className="bg-white border border-slate-200 rounded-xl p-5 shadow-xs">
            <div className="flex justify-between items-center mb-3">
              <span className="text-xs font-semibold uppercase tracking-wider text-slate-500">
                Fixed Daily Budget
              </span>
              <span className="text-xs bg-blue-50 text-blue-700 px-2 py-0.5 rounded font-medium">
                Baseline
              </span>
            </div>
            <div className="text-3xl font-bold text-slate-900">
              Rs. {dashboard.fixedDailyBudget.toLocaleString()}
              <span className="text-sm font-normal text-slate-400"> / day</span>
            </div>
            <p className="text-xs text-slate-500 mt-3">Standard base allocation</p>
          </div>

          {/* Card 3: Spent Today */}
          <div className="bg-white border border-slate-200 rounded-xl p-5 shadow-xs">
            <div className="flex justify-between items-center mb-3">
              <span className="text-xs font-semibold uppercase tracking-wider text-slate-500">
                Spent Today
              </span>
              <span className="text-xs text-emerald-600 font-medium">
                {dashboard.fixedRemainingToday >= 0 ? "Under target" : "Over target"}
              </span>
            </div>
            <div className="text-3xl font-bold text-slate-900">
              Rs. {dashboard.spentToday.toLocaleString()}
              <span className="text-sm font-normal text-slate-400"> spent</span>
            </div>

            {/* Progress Bar */}
            <div className="w-full bg-slate-100 h-2 rounded-full overflow-hidden mt-3">
              <div
                className="bg-emerald-600 h-full transition-all"
                style={{ width: `${dailyPercentUsed}%` }}
              />
            </div>
            <div className="flex justify-between text-xs mt-1.5">
              <span className="text-emerald-600 font-medium">
                Rs. {dashboard.fixedRemainingToday.toLocaleString()} left today
              </span>
              <span className="text-slate-400">{dailyPercentUsed}% used</span>
            </div>
          </div>

        </div>

        {/* Monthly Budget Breakdown Card */}
        <div className="bg-white border border-slate-200 rounded-xl p-6 shadow-xs">
          <h2 className="text-lg font-bold text-slate-900">Monthly Budget Breakdown</h2>
          <p className="text-xs text-slate-500 mb-5">
            Macro cycle distribution and remaining safe buffer
          </p>

          <div className="grid grid-cols-1 sm:grid-cols-3 gap-4 bg-slate-50 p-4 rounded-xl border border-slate-100 mb-5">
            <div>
              <span className="text-xs font-semibold uppercase text-slate-400">Monthly Budget</span>
              <div className="text-2xl font-bold text-slate-900 mt-1">
                Rs. {dashboard.monthlyBudget.toLocaleString()}
              </div>
            </div>
            <div>
              <span className="text-xs font-semibold uppercase text-slate-400">Monthly Spent</span>
              <div className="text-2xl font-bold text-slate-900 mt-1">
                Rs. {dashboard.spentThisMonth.toLocaleString()}
              </div>
            </div>
            <div>
              <span className="text-xs font-semibold uppercase text-slate-400">Remaining</span>
              <div className="text-2xl font-bold text-emerald-600 mt-1">
                Rs. {dashboard.remainingThisMonth.toLocaleString()}
              </div>
            </div>
          </div>

          {/* Monthly Utilization Progress Bar */}
          <div className="flex justify-between text-xs font-medium mb-1.5">
            <span className="text-slate-600">Utilization</span>
            <span className="text-slate-900">
              {monthlyPercentUsed}% of Rs. {dashboard.monthlyBudget.toLocaleString()}
            </span>
          </div>
          <div className="w-full bg-slate-100 h-2.5 rounded-full overflow-hidden">
            <div
              className="bg-slate-900 h-full transition-all"
              style={{ width: `${monthlyPercentUsed}%` }}
            />
          </div>
        </div>

      </div>
    </div>
  );
}

export default App;