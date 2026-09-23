#!/usr/bin/env zsh
set -euo pipefail

# Скрипт применяет миграции к БД (аналог update-database.bat)
# Usage: ./update-database.sh [TargetMigration]
# Если TargetMigration не указан, применяются все миграции (dotnet ef database update)

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
  echo "Usage: $(basename \"$0\") [TargetMigration]"
  echo "Если TargetMigration не указан, будут применены все миграции."
  echo "Пример: $(basename \"$0\") 20231005120000_Initial"
  exit 0
fi

TARGET="${1:-}"

if [[ -z "$TARGET" ]]; then
  dotnet ef database update \
    --startup-project "$SCRIPT_DIR/WebApi/WebApi.csproj" \
    --project "$SCRIPT_DIR/Infrastructure/Infrastructure.EntityFramework/Infrastructure.EntityFramework.csproj" \
    --context DatabaseContext
else
  dotnet ef database update "$TARGET" \
    --startup-project "$SCRIPT_DIR/WebApi/WebApi.csproj" \
    --project "$SCRIPT_DIR/Infrastructure/Infrastructure.EntityFramework/Infrastructure.EntityFramework.csproj" \
    --context DatabaseContext
fi

read -n1 -r -s -p $'\nНажмите любую клавишу, чтобы продолжить...'
