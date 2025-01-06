
# Console-Based Banking System

A simple console-based banking system built using .NET that provides users with essential banking functionalities. This project includes features for account management, transaction handling, and error validation to ensure a seamless user experience.

---

## Features

### 1. Main Menu
- Display options for:
  - Create Account
  - View Account
  - Deposit Money
  - Withdraw Money
  - View Transaction History
  - Exit the application

### 2. Account Management
- **Create Account**:  
  Allows users to create a new account by providing the following details:
  - **Account Number** (generated automatically)
  - **Name** (validated to allow only letters and spaces)
  - **Initial Balance** (positive number only)
  
- **View Account**:  
  Displays the details of a specific account based on the Account Number:
  - Account ID
  - Account Holder Name
  - Current Balance

### 3. Transaction Features
- **Deposit Money**:  
  Enables users to deposit a specified amount into an account. Updates the balance and logs the transaction.

- **Withdraw Money**:  
  Allows users to withdraw money with a balance check to prevent overdrafts. Updates the balance and logs the transaction.

### 4. Transaction History
- Maintains a list of transactions (type, amount, date) for each account.
- Users can view the transaction history of a specific account using the Account Number.

### 5. Error Handling
- Provides appropriate error messages for:
  - Invalid inputs (e.g., non-numeric values, negative amounts)
  - Insufficient balance during withdrawal
  - Non-existent Account Numbers

### 6. Validation
- **Account Number**: Ensures uniqueness for each account.
- **Name**: Validates to allow only alphabetic characters and spaces.
- **Transaction Amounts**: Validates to allow only positive numbers.

---

## Installation and Usage

### Prerequisites
- .NET SDK installed on your machine.

### Running the Project
1. Clone the repository or download the source code.
2. Open the project in your preferred IDE (e.g., Visual Studio).
3. Build the project to ensure there are no compilation errors.
4. Run the application. The Main Menu will be displayed in the console.

---

## How to Use

1. **Main Menu**: Select an option by entering the corresponding number (1-6).
2. **Create Account**:
   - Enter the name and initial deposit amount when prompted.
   - A unique Account Number will be generated automatically.
3. **View Account**:
   - Enter the Account Number to view account details.
4. **Deposit Money**:
   - Enter the Account Number and the amount to deposit.
5. **Withdraw Money**:
   - Enter the Account Number and the amount to withdraw.
   - Ensure sufficient balance exists in the account.
6. **View Transaction History**:
   - Enter the Account Number to view all previous transactions.

---

## Example Usage

### Creating an Account
```plaintext
Enter account holder name: John Doe
Enter initial deposit: 1000
Account created successfully! Account ID: 1
```

### Deposit Money
```plaintext
Enter account ID: 1
Enter deposit amount: 500
Deposit successful!
```

### View Account
```plaintext
--- Account Details ---
Account ID: 1
Holder Name: John Doe
Balance: 1500.00
```

---

## Error Handling Examples
- **Invalid Input**:  
  _"Invalid amount. Please enter a positive number."_
- **Non-existent Account**:  
  _"Invalid account ID."_
- **Insufficient Balance**:  
  _"Insufficient funds for withdrawal."_

---

## Technologies Used
- **Programming Language**: C#
- **Development Environment**: .NET Framework / .NET Core
- **IDE**: Visual Studio or equivalent

---

## Project Structure
- **Account Class**: Represents an account with properties for Account ID, Name, Balance, and Transaction History.
- **Program Class**: Handles the application logic, including menu navigation, account management, and transaction handling.


