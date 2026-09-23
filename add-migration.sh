#!/usr/bin/env zsh
set -euo pipefail

# Скрипт добавляет миграцию (аналог add migration.bat)
# Usage: ./add-migration.sh [MigrationName]

SCRIPT_DIR="$(cd "$(dirname "${0}")" && pwd)"

command_exists() {
  command -v "$1" >/dev/null 2>&1
}

if ! command_exists dotnet; then
  echo "Ошибка: 'dotnet' не найден. Установите .NET SDK: https://dotnet.microsoft.com/download"
  exit 1
fi

# Проверка наличия dotnet-ef (dotnet ef)
if ! dotnet ef --version >/dev/null 2>&1; then
  echo "Ошибка: 'dotnet ef' недоступен. Установите глобальный инструмент 'dotnet-ef':"
  echo "  dotnet tool install --global dotnet-ef"
  exit 1
fi

if [[ "${1:-}" == "-h" || "${1:-}" == "--help" ]]; then
  echo "Usage: $(basename "$0") [MigrationName]"
  echo "Если имя миграции не указано, будет использовано 'Initial'."
  exit 0
fi

MIGRATION_NAME="${1:-Initial}"

dotnet ef migrations add "$MIGRATION_NAME" \
  --startup-project "$SCRIPT_DIR/WebApi/WebApi.csproj" \
  --project "$SCRIPT_DIR/Infrastructure/Infrastructure.EntityFramework/Infrastructure.EntityFramework.csproj" \
  --context DatabaseContext

# Пауза, чтобы поведение было похоже на PAUSE в .bat
read -n1 -r -s -p $'\nНажмите любую клавишу, чтобы продолжить...'
