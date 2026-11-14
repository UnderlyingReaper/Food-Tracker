import type { BudgetDashboard, CreateBudget, EditBudget, Budget } from "../types/budget";

const BASE_URL = `${import.meta.env.VITE_API_BASE_URL}/budget`;

export const BudgetAPI = {
    getBudget: async(): Promise<Budget | null> => {
        const response = await fetch(BASE_URL);

        if(response.status === 404)
            throw new Error("Budget does not exist");
        else if(!response.ok)
            throw new Error("Failed to get budget");

        return response.json();
    },

    createBudget: async(budget: CreateBudget): Promise<void> => {
        const response = await fetch(BASE_URL, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(budget)
        });

        if(!response.ok) {
            throw new Error("Failed to create budget");
        }

        return response.json();
    },

    updateBudget: async(budget: EditBudget): Promise<void> => {
        const response = await fetch(BASE_URL, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },

            body: JSON.stringify(budget)
        });

        if(!response.ok)
            throw new Error("Failed to update budget");

        return response.json();
    },

    getDashboard: async(): Promise<BudgetDashboard | null> => {
        const response = await fetch(`${BASE_URL}/dashboard`);

        if(response.status === 404) {
            return null;
        }
        else if(!response.ok) {
            throw new Error("Failed to fetch budget dashboard");
        }

        return response.json();
    }
}