# WORD FREQUENCY COUNTER – P006
CLOOPS Microservices | NATS | C#

📌 OVERVIEW

This project implements P006: Word Frequency Counter using the
cloops.microservices SDK and NATS.

The microservice listens on a NATS subject, processes a text input,
counts word frequencies, and returns the top N most frequent words
according to the defined rules.

✨ FEATURES

• 📡 NATS request–reply microservice
• 🎯 Listens on subject: word.frequency
• 🔤 Converts text to lowercase
• ✂️ Splits text using whitespace and punctuation
• 📊 Counts frequency of each word
• 🔽 Sorting rules:

Frequency in descending order

Alphabetical order for ties
• 🧮 Returns only top N words
• ⚠️ Handles edge cases gracefully

🛠️ TECHNOLOGY STACK

Language : C# (.NET)
Framework : cloops.microservices
Messaging : NATS
Operating System: Windows 11

📁 PROJECT STRUCTURE

WordFrequency
│
├── controllers
│ ├── nats.health.controller.cs
│ └── nats.word.frequency.controller.cs
│
├── services
│ ├── word.frequency.logic.cs
│ ├── word.frequency.models.cs
│ ├── word.frequency.response.cs
│ └── echo.service.cs
│
├── Program.cs
├── .env
└── WordFrequency.csproj

⚙️ CONFIGURATION

This project uses environment variables for configuration.

.env file contents:

NATS_URL=nats://localhost:4222
ENABLE_NATS_CONSUMERS=true
DOTNET_ENVIRONMENT=Development
DEBUG=false

⚠️ IMPORTANT
On Windows, .env files are NOT automatically loaded.
Environment variables must be set manually in PowerShell.

▶️ RUNNING THE SERVICE (WINDOWS 11)

🔹 Step 1: Start NATS Server
Ensure nats-server.exe is running on port 4222.

🔹 Step 2: Set Environment Variables (PowerShell)

$env:NATS_URL="nats://localhost:4222"
$env:ENABLE_NATS_CONSUMERS="true"

🔹 Step 3: Run the Microservice

dotnet run --project WordFrequency

Startup logs should confirm:
✔ Enable NATS Consumers: True
✔ Subscribed to subject: word.frequency

🧪 TESTING WITH NATS CLI

📥 Install the NATS CLI from:
https://github.com/nats-io/natscli/releases

📄 Create a request file named req.json:

text: "hello hello world"
topN: 2

📤 Send the request:

Get-Content req.json -Raw | nats request word.frequency --send-on eof

✅ EXPECTED RESPONSE

wordFrequencies:
• hello : 2
• world : 1

totalWords: 3

📥 REQUEST FORMAT

text: "the quick brown fox jumps over the lazy dog the fox"
topN: 3

📤 RESPONSE FORMAT

wordFrequencies:
• the : 3
• fox : 2
• quick : 1

totalWords: 10

⚠️ EDGE CASE HANDLING

• Empty text returns an empty word list
• topN ≤ 0 returns an error response
• topN greater than unique words returns all words
• Non-alphanumeric characters are ignored

<img width="1323" height="433" alt="image" src="https://github.com/user-attachments/assets/8dfbf0f6-095f-4053-8163-816f731581ca" />
<img width="1433" height="625" alt="image" src="https://github.com/user-attachments/assets/09f53ef8-03a2-47a1-b1c9-0eba76058415" />
<img width="1449" height="177" alt="image" src="https://github.com/user-attachments/assets/4ad5cbca-2cbb-4611-af37-58b1074db81d" />



