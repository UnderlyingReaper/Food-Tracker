export interface Budget {
    iD: number;
    monthlyBudget: number;
    dailyBudget: number;
    updated: Date;
}

export interface CreateBudget {
    monthlyBudget: number;
    dailyBudget: number;
}

export interface EditBudget {
    monthlyBudget: number;
    dailyBudget: number;
    updated: Date;
}

export interface BudgetDashboard {
    monthlyBudget: number;
    spentThisMonth: number;
    remainingThisMonth: number;

    fixedDailyBudget: number;
    dynamicDailyBudget: number;

    spentToday: number;

    fixedRemainingToday: number;
    dynamicRemainingToday: number;
}