const PROXY_CONFIG = [
  {
    context: [
      "/contact",
    ],
    target: "https://localhost:7174",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
