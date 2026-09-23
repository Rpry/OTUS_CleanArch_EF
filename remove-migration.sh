#!/usr/bin/env zsh
set -euo pipefail

# Скрипт удаляет последнюю миграцию (аналог remove migration.bat)
# Usage: ./remove-migration.sh

SCRIPT_DIR="$(cd "$(dirname "${0}")" && pwd)"

command_exists() {
  command -v "$1" >/dev/null 2>&1
}

if ! command_exists dotnet; then
  echo "Ошибка: 'dotnet' не найден. Установите .NET SDK: https://dotnet.microsoft.com/download"
  exit 1
fi

if ! dotnet ef --version >/dev/null 2>&1; then
  echo "Ошибка: 'dotnet ef' недоступен. Установите глобальный инструмент 'dotnet-ef':"
  echo "  dotnet tool install --global dotnet-ef"
  exit 1
fi

if [[ "${1:-}" == "-h" || "${1:-}" == "--help" ]]; then
  echo "Usage: $(basename "$0")"
  echo "Удаляет последнюю миграцию в проекте миграций."
  exit 0
fi

# Выполнение команды удаления миграции
dotnet ef migrations remove \
  --startup-project "$SCRIPT_DIR/WebApi/WebApi.csproj" \
  --project "$SCRIPT_DIR/Infrastructure/Infrastructure.EntityFramework/Infrastructure.EntityFramework.csproj" \
  --context DatabaseContext

read -n1 -r -s -p $'\nНажмите любую клавишу, чтобы продолжить...'
